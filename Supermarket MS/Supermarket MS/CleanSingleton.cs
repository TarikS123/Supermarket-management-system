using SupermarketMS;

namespace SupermarketMS
{
    public class CleanJobSingleton  // sluzi da se moze voditi evidencija o poslovima za higijenicare tj koji department treba ocistiti
    {
        private static CleanJobSingleton instance;
        private List<DirtyDepartment> dirtyDepartments;
        public CleanJobSingleton()
        {
            dirtyDepartments = new List<DirtyDepartment> ();
        }
        public static CleanJobSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CleanJobSingleton();
                }
                return instance;
            }

        }

        public void AddCleaningJob(DirtyDepartment department)
        {
            dirtyDepartments.Add (department);  
        }
        public void CleanDepartment(string department)
        {
            foreach(DirtyDepartment d in dirtyDepartments)
            {
                if (d.Department.Equals(department)) dirtyDepartments.Remove(d);
            }

        }
    }

    public class DirtyDepartment
    {
        public string Department {  get; set; }
        public string CleaningDescription {  get; set; }

        public DirtyDepartment(string dep, string desc) {
        Department = dep;
        CleaningDescription = desc;
        }
    }
}
