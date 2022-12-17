using System;


namespace Task
{
    abstract class Storage{
        private static int currentID;//Static field currentID stores the ID of the last created object

        protected abstract int ID { get; set; }
        protected abstract string Capacity { get; set; }
        protected abstract string Data { get; set; }

        public Storage()
        {
            ID = 0;
            Data = "No data";
            Capacity = "0GB";
        }
        public Storage(string Data, string Capacity)
        {
            ID = GetNextID();
            this.Data = Data;
            this.Capacity = Capacity;
        }
        // Static constructor to initialize the static member, currentID. This
        // constructor is called one time, automatically, before any instance
        static Storage() => currentID = 0;

        protected int GetNextID() => ++currentID;
    }

    class LocalStorage : Storage
    {
        protected override int ID { get; set; }
        protected override string Capacity { get; set; }
        protected override string Data { get; set; }

        public void Update(string Data, string Capacity)
        {
            this.Data = Data;
            this.Capacity = Capacity;
        }
        public virtual void Display()
        {
            Console.WriteLine("Local storage");
        }
    }
    class CloudStorage:LocalStorage
    {
        public override void Display()
        {
            Console.WriteLine("Cloud storage");
        }
        private void DisplayService(string service)
        {
            Console.WriteLine("Service: " + service);//for example Google Drive
        }
    }
    class RemovableStorage : LocalStorage
    {
        public override void Display()
        {
            Console.WriteLine("Removable storage");
        }

    }
}
