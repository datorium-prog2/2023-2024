using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DataStructures
{
    public class TreeNode
    {
        public List<CustomFile> CustomFiles { get; set; } = new List<CustomFile>();
        public List<TreeNode> Nodes { get; set; } = new List<TreeNode>();
        public string Name { get; set; }
    }

    public class CustomFile
    {
        public string Name { get; set; }
        public string Extension { get; set; }
        public string Path { get; set; }
    }

    public class TreeExample
    {
        private string SaveFilePath = ".\\folder_structure.txt"; //Json atrašanās vieta
        public string CurrentPath { get; set; }
        public TreeNode Root { get; set; }
        public TreeNode CurrentNode { get; set; }

        public TreeExample()
        {
            ReadFolderStructure();
            if (Root == null)
            {
                Root = new TreeNode()
                {
                    Name = "Man ira vienalga",
                };
            }
            CurrentNode = Root;
            AddFolder("Gorum borum");
            SaveFolderStructure();
        }

        public void SaveFolderStructure()
        {
            string SerializedRoot = JsonSerializer.Serialize(Root); //Pārveido koku uz JSON
            var stream = File.Create(SaveFilePath); //Izveido failu konkrētajā atrašanās vietā un atver stream
            byte[] bytes = Encoding.ASCII.GetBytes(SerializedRoot); //Pārveido uz byte[]
            stream.Write(bytes); //Saglabā byte masīvu failā
            stream.Close(); //Aizver stream
        }

        //Funkcija, kas pievienos folderi current atrašanās vietā
        public void AddFolder(string folderName)
        {
            var folder = new TreeNode()
            {
                Name = folderName,
            };


            CurrentNode.Nodes.Add(folder);
        }

        //Funkcija, kas pievienos failu, current atrašanās vietā

        public void ReadFolderStructure()
        {
            if (!File.Exists(SaveFilePath))
            {
                return;
            }

            using (StreamReader sr = File.OpenText(SaveFilePath))
            {
                string json = sr.ReadToEnd();
                Root = JsonSerializer.Deserialize<TreeNode>(json);
            }

        }
    }
}

