namespace HashRenamer
{
    class itemClass
    {
        public string currentFilePath { get; set; }
        public string newFilePath { get; set; }
        public string currentName { get; set; }
        public string newName { get; set; }
        public string hash { get; set; }
        public bool queued { get; set; }
        public bool skip { get; set; }

        public itemClass(string path, string name)
        {
            queued = true;
            skip = false;
            hash = "";
            currentName = name;
            newName = "";
            currentFilePath = path;
            newFilePath = "";
        }
    }
}
