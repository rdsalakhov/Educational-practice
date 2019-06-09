using System.Collections.Generic;

namespace Task7
{
    /// <summary>
    /// Класс описывает дерево кодирования
    /// </summary>
    class CodeTree
    {
        List<CodeTreeNode> lastNodes;

        private CodeTreeNode root;

        private List<CodeTreeNode> currentNodes;

        /// <summary>
        /// Создание дерева кодирования по таблице частот
        /// </summary>
        /// <param name="frequencyTable"></param>
        public CodeTree(FrequencyTable frequencyTable)
        {
            lastNodes = new List<CodeTreeNode>();
            foreach (var i in frequencyTable)
            {
                lastNodes.Add(new CodeTreeNode(i.Value,i.Key, null, null));
            }
            currentNodes = new List<CodeTreeNode>();
            foreach (var i in lastNodes)
            {
                currentNodes.Add(i);
            }
            BuildTree();
        }

        /// <summary>
        /// Создание нового узла из двух с минимальной суммарной частотой
        /// </summary>
        private void CreateNewNode()
        {
                currentNodes.Sort(new FrequencyComparer());
                double newFrequency = currentNodes[0].Frequency + currentNodes[1].Frequency;
                var newNode = new CodeTreeNode(newFrequency, currentNodes[1], currentNodes[0]);
                currentNodes.RemoveAt(0);
                currentNodes.RemoveAt(0);
                currentNodes.Add(newNode);
        }
        
        /// <summary>
        /// Последовательное преобразование всех узлов из currentNodes в дерево кодирования
        /// </summary>
        private void BuildTree()
        {
            while (currentNodes.Count > 1)
            {
                CreateNewNode();
            }
            root = currentNodes[0];
        }

        /// <summary>
        /// Создание таблицы кодов по узлам lastNodes
        /// </summary>
        /// <returns></returns>
        public SortedDictionary<string, string> CreateCodeTable()
        {
            GenerateCodes(root, "");
            var codeTable = new SortedDictionary<string, string>();
            foreach (var node in lastNodes)
            {
                codeTable.Add(node.Code, node.Letter);
            }
            return codeTable;
        }


        /// <summary>
        /// Рекурсивный обход дерева с записью кода в каждый узел lastNodes
        /// </summary>
        /// <param name="node"></param>
        /// <param name="code"></param>
        private void GenerateCodes(CodeTreeNode node, string code)
        {            
            if (node.leftLink == null && node.rightLink == null) return;
            else
            {
                string leftCode = code + "0";
                string rightCode = code + "1";
                node.leftLink.Code = leftCode;
                node.rightLink.Code = rightCode;
                GenerateCodes(node.leftLink, leftCode);
                GenerateCodes(node.rightLink, rightCode);
            }
        }
    }
}
