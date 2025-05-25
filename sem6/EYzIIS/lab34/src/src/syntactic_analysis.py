from natasha import (
    Segmenter,
    NewsEmbedding,
    NewsSyntaxParser,
    NewsMorphTagger,
    MorphVocab,
    Doc
)
from ipymarkup import format_dep_markup
from natasha.syntax import markup_words, token_deps


segmenter = Segmenter()
emb = NewsEmbedding()
morph_vocab = MorphVocab()
morph_tagger = NewsMorphTagger(emb)
syntax_parser = NewsSyntaxParser(emb)


translations = {
    "root": "Корень",
    "nsubj": "Субъект",
    "obj": "Объект",
    "advcl": "Обстоятельственный модификатор",
    "acl": "Атрибутивный модификатор",
    "case": "Падеж",
    "amod": "Адъективный модификатор",
    "advmod": "Обстоятельственный модификатор",
    "nsubj:pass": "Субъект пассивный",
    "det": "Определение",
    "num": "Числительное",
    "appos": "Аппозиция",
    "clf": "Классификатор",
    "compound": "Составное слово",
    "fixed": "Фиксированное сочетание",
    "flat": "Плоское сочетание",
    "orphan": "Особый случай",
    "parataxis": "Паратаксис",
    "punct": "Пунктуация",
    "vocative": "Вокатив",
    "xcomp": "Открытый клаузальный комплемент",
    "nmod": "Именной модификатор",
    "obl": "Обстоятельственный компонент",
    "conj": "Сочинение",
    "csubj": "Клаузальный субъект",
    "cc": "Сочинительный союз",
    'mark': 'Gодчинительный союз',
    'ccomp': 'клауза-комплемент с глагольным сказуемым',
}


class SyntacticAnalyzer:
    def __init__(self, text: str):
        self.text = text
        self.doc = Doc(text)
        self.doc.segment(segmenter)        # Сегментация
        self.doc.tag_morph(morph_tagger)   # Морфоанализ
        self.doc.parse_syntax(syntax_parser)  # Синтаксический разбор
        
        self.tokens = []
        for token in self.doc.tokens:
            token.lemmatize(morph_vocab)   # Лемматизация
            self.tokens.append({
                "token": token.text,
                "rel": token.rel,          
                "head_id": token.head_id,
                "pos": token.pos,
                "lemma": token.lemma
            })

    def get_tokens(self) -> list:
        return self.tokens
    
def show_span_tree(markup):
    words = markup_words(markup)
    deps = token_deps(markup.tokens)
    # for dep in deps:
    #     dep = dep[0], dep[1], translations.get(dep[2], dep[2])
    return '\n'.join(format_dep_markup(words, deps))

def generate_syntactic_html(analizer: SyntacticAnalyzer) -> str:
    trees = show_span_tree(analizer.doc.syntax)
    tokens = analizer.get_tokens()
    trees_markup = ''.join(trees)

    html = f"""
    <!DOCTYPE html>
    <html>
    <head>
        <style>
            body {{
                font-size: 17px;
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
            table {{
                border-collapse: collapse;
                width: 100vw;
                max-width: 600px;
                margin: 20px;
            }}
            th, td {{
                padding: 10px;
                text-align: left;
                border-bottom: 1px solid #ddd;
            }}
            th {{
                background-color: #f2f2f2;
            }}
            .section {{
                margin-bottom: 30px;
            }}
            .tag {{
                display: inline-block;
                width: 15px;
                height: 15px;
                margin-right: 5px;
                border-radius: 50%;
                border: 1px solid #ccc;
            }}
            #token-container {{
                padding: 10px;
                border: 1px solid #ccc;
                line-height: 25px;
            }}
            .custom-button {{
                padding: 10px 20px;
                font-size: 16px;
                font-weight: bold;
                border: none;
                border-radius: 4px;
                background-color: #4CAF50;
                color: white;
                cursor: pointer;
                transition: background-color 0.3s ease;
            }}
            .custom-button:hover {{
                background-color: #45a049;
            }}
        </style>
    </head>
    <body>
        <div style="text-align: center; padding: 10px;">
            <button class="custom-button" onclick="saveHtml()">Сохранить результат</button>
        </div>
        <div id="token-container">
            {''.join(f'<span class="hovertip" data-dep="{translations.get(t["rel"], t["rel"])}" onclick="changeDep(this)">{t["token"]}</span> ' for t in tokens)}
        </div>
        <table>
            <tr><th>Тег</th><th>Цвет</th></tr>
            <tr><td><span class="tag" style="background-color: darkred;"></span>Корень</td><td>Тёмно-красный</td></tr>
            <tr><td><span class="tag" style="background-color: darkgreen;"></span>Субъект</td><td>Тёмно-зелёный</td></tr>
            <tr><td><span class="tag" style="background-color: darkblue;"></span>Объект</td><td>Тёмно-синий</td></tr>
            <tr><td><span class="tag" style="background-color: purple;"></span>Адъективный модификатор</td><td>Фиолетовый</td></tr>
            <tr><td><span class="tag" style="background-color: teal;"></span>Обстоятельственный модификатор</td><td>Турко-зелёный</td></tr>
            <tr><td><span class="tag" style="background-color: maroon;"></span>Определение</td><td>Мароновый</td></tr>
            <tr><td><span class="tag" style="background-color: orange;"></span>Числительное</td><td>Оранжевый</td></tr>
            <tr><td><span class="tag" style="background-color: darkgoldenrod;"></span>Падеж</td><td>Тёмный золотистый</td></tr>
            <tr><td><span class="tag" style="background-color: firebrick;"></span>Составное слово</td><td>Красно-коричневый</td></tr>
        </table>

        <div class="section">
            <h2>Синтаксические деревья</h2>
            <div>
                {trees_markup}
            </div>
        </div>

        <script>
            function renewUnderlining() {{
                const elements = document.querySelectorAll('[data-dep]');
                elements.forEach(element => {{
                    const dep = element.getAttribute('data-dep');
                    element.style.color = null;
                    switch (dep) {{
                        case 'Корень': element.style.color = 'darkred'; break;
                        case 'Субъект': element.style.color = 'darkgreen'; break;
                        case 'Объект': element.style.color = 'darkblue'; break;
                        case 'Адъективный модификатор': element.style.color = 'purple'; break;
                        case 'Обстоятельственный модификатор': element.style.color = 'teal'; break;
                        case 'Определение': element.style.color = 'maroon'; break;
                        case 'Числительное': element.style.color = 'orange'; break;
                        case 'Падеж': element.style.color = 'darkgoldenrod'; break;
                        case 'Составное слово': element.style.color = 'firebrick'; break;
                        default: element.style.color = 'black'; break;
                    }}
                }});
            }}

            function changeDep(token) {{
                const newDep = prompt("Введите новое значение зависимости:", token.dataset.dep);
                if (newDep !== null) {{
                    token.dataset.dep = newDep;
                    renewUnderlining();
                }}
            }}

            function saveHtml() {{
                const blob = new Blob([document.documentElement.outerHTML], {{type: "text/html"}});
                const url = URL.createObjectURL(blob);
                const a = document.createElement('a');
                a.href = url;
                a.download = "syntactic_analysis.html";
                a.click();
            }}

            document.addEventListener('DOMContentLoaded', () => {{
                renewUnderlining();
            }});
        </script>
    </body>
    </html>
    """
    return html