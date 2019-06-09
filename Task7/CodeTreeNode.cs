using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7
{

    /// <summary>
    /// Класс описывает узел дерева кодирования
    /// </summary>
    class CodeTreeNode
    {
        public double Frequency {get; set;}

        public string Letter { get; set; }

        public CodeTreeNode leftLink;

        public CodeTreeNode rightLink;

        public string Code { get; set; }
       
        public CodeTreeNode(double frequency, CodeTreeNode leftLink, CodeTreeNode rightLink)
        {
            this.Frequency = frequency;
            this.Letter = null;
            this.leftLink = leftLink;
            this.rightLink = rightLink;
            this.Code = "";
        }

        public CodeTreeNode(double frequency, string codeLetter, CodeTreeNode leftLink, CodeTreeNode rightLink)
        {
            this.Frequency = frequency;
            this.Letter = codeLetter;
            this.leftLink = leftLink;
            this.rightLink = rightLink;
            this.Code = "";
        }

    }
}
