﻿namespace CompanySampleDataImporter.Importer.Importers
{
    using CompanySampleDataImporter.Data;
    using System;
    using System.IO;
    using System.Linq;
    public class ReportsImporter : IImporter
    {
        public string Message
        {
            get { return "Importing reports"; }
        }

        public int Order
        {
            get { return 5; }
        }

        public Action<CompanyEntities, TextWriter> Get
        {
            get
            {
                return (db, tr) =>
                {
                    var employeeIds =
                        db.Employees
                        .Select(e => e.Id)
                        .ToList();

                    for (int i = 0; i < employeeIds.Count; i++)
                    {
                        var numberOfReports = RandomGenerator.GetRandomNumber(25, 75);

                        for (int j = 0; j < numberOfReports; j++)
                        {
                            var report = new Report
                            {
                                EmployeeId = employeeIds[i],
                                Time = RandomGenerator.GetRandomDate(before: DateTime.Now),


                            };

                            db.Reports.Add(report);
                        }

                        tr.Write(".");

                        db.SaveChanges();
                        db.Dispose();
                        db = new CompanyEntities();
                    }
                };
            }
        }
    }
}
