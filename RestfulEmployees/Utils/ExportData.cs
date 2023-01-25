using RestfulEmployees.Models;

namespace RestfulEmployees.Utils
{
    public static class ExportData
    {
        public static void ExportCsv(List<EmployeeModel> employee, string fileName)
        {
            using(StreamWriter sw = new StreamWriter(@fileName,true))
            {
                foreach (var item in employee)
                {
                    sw.WriteLine(item.FirstName +","+ item.LastName + "," + item.Email + "," 
                        + item.BirthDate + "," + item.DepartmentId);
                }
            }
        }
    }
}
