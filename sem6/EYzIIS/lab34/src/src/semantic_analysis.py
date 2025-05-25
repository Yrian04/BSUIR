from natasha import (
    Segmenter,
    NewsEmbedding,
    NewsSyntaxParser,
    NewsMorphTagger,
    Doc,
    NamesExtractor,
    MorphVocab,
    NewsNERTagger
)
from pymorphy2 import MorphAnalyzer
from collections import Counter
from heapq import nlargest
from stop_words import get_stop_words
import re

segmenter = Segmenter()
emb = NewsEmbedding()
morph = MorphAnalyzer()
morph_vocab = MorphVocab()
morph_tagger = NewsMorphTagger(emb)
syntax = NewsSyntaxParser(emb)
ner_tagger = NewsNERTagger(emb)
names_extractor = NamesExtractor(morph_vocab)

class SemanticAnalysis:
    def __init__(self, text: str):
        self.text = text
        self.doc = Doc(text)
        self.doc.segment(segmenter)
        self.doc.tag_morph(morph_tagger)
        self.doc.parse_syntax(syntax)
        self.doc.tag_ner(ner_tagger)
        
        # Аннотация слов
        self.text_annotated = []
        for token in self.doc.tokens:
            token.lemmatize(morph_vocab)
            lemma = token.lemma
            pos = token.pos
            self.text_annotated.append({
                "text": token.text,
                "def": f"Лемма: {lemma}, Часть речи: {pos}"
            })
        
        self.entities = self._extract_entities()
        
        self.keywords = self._extract_keywords(text)

    def _extract_entities(self) -> dict:
        entities = {}
        names_extractor(self.doc)
        for span in self.doc.spans:
            entities[span.text] = {
                "text": span.text,
                "label": span.type  
            }
        return entities

    def _extract_keywords(self, text: str) -> list:
        stop_words = get_stop_words('russian')
        words = [word for word in re.findall(r'\w+', text.lower()) 
                 if word not in stop_words and len(word) > 2]
        freq = Counter(words)
        max_freq = freq.most_common(1)[0][1] if freq else 1
        normalized = {k: round(v/max_freq, 2) for k, v in freq.items()}
        return sorted(normalized.items(), key=lambda x: -x[1])[:10]

def generate_semantic_html(analysis: SemanticAnalysis) -> str:
    keyword_items = ''.join(f'<li><span class="keyword">{k}</span> ({v})</li>' 
                           for k, v in analysis.keywords)
    
    entity_items = ''.join(f'<li><span class="entity">{e["text"]}</span> ({e["label"]})</li>' 
                          for e in analysis.entities.values())
    
    html = f"""
    <!DOCTYPE html>
    <html>
    <head>
        <style>
            body {{
                font-family: Arial, sans-serif;
                margin: 20px;
            }}
            h1 {{
                color: #333;
            }}
            .section {{
                margin-bottom: 30px;
            }}
            .text-field {{
                border: 1px solid #ccc;
                padding: 10px;
                width: 80%;
                margin-bottom: 10px;
            }}
            .list-field {{
                list-style-type: none;
                padding: 0;
                margin: 0;
            }}
            .list-field li {{
                margin-bottom: 5px;
            }}
            .keyword {{
                font-weight: bold;
            }}
            .entity {{
                font-style: italic;
            }}
            .hovertip {{
                position: relative;
                display: inline-block;
                cursor: pointer;
            }}
            .hovertip:hover::after {{
                content: attr(data-dep);
                position: absolute;
                bottom: 125%;
                left: 50%;
                transform: translateX(-50%);
                padding: 5px;
                background-color: #000;
                color: #fff;
                border-radius: 4px;
                white-space: nowrap;
            }}
        </style>
        <script>
            function saveHtml() {{
                const blob = new Blob([document.documentElement.outerHTML], {{type: "text/html"}});
                const url = URL.createObjectURL(blob);
                const a = document.createElement('a');
                a.href = url;
                a.download = "semantic_analysis.html";
                a.click();
            }}
        </script>
    </head>
    <body>
        <div style="text-align: center; padding: 10px;">
            <button onclick="saveHtml()">Сохранить</button>
        </div>
        <h1>Семантический анализ</h1>
        
        <div class="section">
            <h2>Аннотированный текст</h2>
            <div id="token-container">
                {''.join(
                    f'<span class="hovertip" data-dep="{t["def"]}" onclick="changeDep(this)">{t["text"]}</span> ' 
                    for t in analysis.text_annotated
                )}
            </div>
        </div>
        
        <div class="section">
            <h2></h2>
            
        </div>
        
        <div class="section">
            <h2>Ключевые слова</h2>
            <ul class="list-field">
                {keyword_items}
            </ul>
        </div>
        
        <div class="section">
            <h2>Сущности</h2>
            <ul class="list-field">
                {entity_items}
            </ul>
        </div>
    </body>
    </html>
    """
    return html