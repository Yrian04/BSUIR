// TextViewer.tsx
import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import {
  getTextById,
  getWordFormsByTextId,
  updateWordFormDescription,
} from '../services/api';
import { groupWordFormsByLemma } from '../utils/groupWordForms';
import { TreeNodeComponent } from './Tree';
import { TreeNode } from '../types';

import { Search, Edit2 } from 'lucide-react';

export const TextViewer: React.FC = () => {
  const { textId } = useParams<{ textId: string }>();
  const [fileName, setFileName] = useState<string | null>(null);
  const [wordForms, setWordForms] = useState<TreeNode[]>([]);
  const [currentPage, setCurrentPage] = useState(1);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);
  

  useEffect(() => {
    const fetchData = async () => {
      try {
        const textData = await getTextById(Number(textId));
        setFileName(textData.file); // ✅ Теперь получаем имя файла

        const wordFormData = await getWordFormsByTextId(Number(textId), currentPage);
        setWordForms(groupWordFormsByLemma(wordFormData));
      } catch (err) {
        console.error('Ошибка загрузки данных:', err);
        setError('Не удалось загрузить текст или словоформы');
      } finally {
        setLoading(false);
      }
    };
    fetchData();
  }, [textId, currentPage]);

  const handleUpdateDescription = async (wordFormId: number, newDesc: string) => {
    try {
      // Найдите нужную словоформу из локального списка
      const [wf] = wordForms
        .flatMap(node => node.type === 'lemma' ? node.children || [] : [])
        .filter(child => child.id === wordFormId);
      
      // if (!wf || !wf.wordForm) return;
  
      alert('onBlur' + wordFormId + newDesc)
      // Сформируйте полный объект WordFormModel
      const updatedWordForm = {
        ...wf.wordForm,
        description: newDesc
      };
  
      // Отправьте полный объект на сервер
      await updateWordFormDescription(Number(textId), wordFormId, updatedWordForm);
  
      // Обновите состояние
      setWordForms(prev =>
        prev.map(lemmaNode => {
          if (lemmaNode.type === 'lemma' && lemmaNode.children) {
            return {
              ...lemmaNode,
              children: lemmaNode.children.map(child =>
                child.id === wordFormId 
                  ? { ...child, description: newDesc } 
                  : child
              )
            };
          }
          return lemmaNode;
        })
      );
    } catch (error) {
      console.error('Ошибка обновления описания:', error);
      alert('Не удалось сохранить изменения');
    }
  };

  if (loading) {
    return (
      <div className="text-center py-10">
        <p className="text-xl">Загрузка...</p>
      </div>
    );
  }

  if (error) {
    return (
      <div className="text-center py-10">
        <p className="text-xl text-red-500">{error}</p>
      </div>
    );
  }

  return (
    <div className="container mx-auto px-4 py-10">
      <div className="mb-6 flex justify-between items-center">
        <h2 className="text-3xl font-bold">Текст #{textId}</h2>
      </div>
  
      {/* ✅ Отображение PDF */}
      {fileName && (
        <div className="mb-8">
          <div className="bg-white rounded-xl shadow-sm overflow-hidden">
            <iframe
              src={`http://localhost:8000/files/${encodeURIComponent(fileName)}`} // ✅ URL до файла
              className="w-full"
              style={{ height: '70vh' }}
              title="PDF Viewer"
            />
          </div>
          <p className="text-sm text-gray-500 mt-2 text-center">
            Просмотр PDF-файла
          </p>
        </div>
      )}

      {/* ✅ Краткая инструкция */}
      <div className="mb-6 p-4 bg-blue-50 border-l-4 border-blue-500 text-blue-700 rounded">
        <h4 className="font-semibold">Как пользоваться:</h4>
        <ul className="list-disc list-inside mt-2 space-y-1">
          <li>🔹 Леммы можно развернуть/свернуть по клику</li>
          <li>📝 Описание словоформы можно редактировать в поле ввода</li>
          <li>🔄 Изменения сохраняются автоматически при потере фокуса</li>
          <li>⬅️➡️ Используйте пагинацию, чтобы просматривать другие страницы</li>
        </ul>
      </div>

      <div className="mb-6">
        <h3 className="text-2xl font-semibold mb-4">Словоформы</h3>
        <div className="bg-white rounded-lg border border-gray-200 p-4">
          {wordForms.map(node => (
            <TreeNodeComponent 
              key={node.id} 
              node={node} 
              onUpdateDescription={handleUpdateDescription} 
            />
          ))}
        </div>
      </div>

      <div className="mt-6 flex justify-center">
        <div className="inline-flex items-center space-x-1">
          <button
            onClick={() => setCurrentPage((p) => Math.max(1, p - 1))}
            disabled={currentPage === 1}
            className="px-3 py-1 bg-gray-200 rounded-md hover:bg-gray-300 disabled:opacity-50"
            title="Перейти на предыдущую страницу" // ✅ Подсказка
          >
            ←
          </button>
          <span className="px-3 py-1">Страница {currentPage}</span>
          <button
            onClick={() => setCurrentPage((p) => p + 1)}
            className="px-3 py-1 bg-blue-600 text-white rounded-md hover:bg-blue-700"
            title="Перейти на следующую страницу" // ✅ Подсказка
          >
            →
          </button>
        </div>
      </div>
    </div>
  );
};