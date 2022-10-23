namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.Data.Models.Enums;
    using SoftJail.DataProcessor.Dto;
    using SoftJail.DataProcessor.ImportDto;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid Data";

        private const string SuccessfullyImportedDepartment = "Imported {0} with {1} cells";

        private const string SuccessfullyImportedPrisoner = "Imported {0} {1} years old";

        private const string SuccessfullyImportedOfficer = "Imported {0} ({1} prisoners)";

        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            var output = new StringBuilder();
            var departments = JsonConvert
                .DeserializeObject<IEnumerable<DepartmentJsonImportModel>>(jsonString);



            foreach (var jsonDepartment in departments)
            {
                if (!IsValid(jsonDepartment) || !jsonDepartment.Cells.Any())
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                var department = new Department()
                {
                    Name = jsonDepartment.Name,
                    //Cells = jsonDepartment.Cells.Select(c => new Cell
                    //{
                    //    CellNumber = c.CellNumber,
                    //    HasWindow = c.HasWindow,
                    //}).ToList()
                };

                bool depValid = true;

                foreach (var cell in jsonDepartment.Cells)
                {
                    if (!IsValid(cell))
                    {
                        break;
                        depValid = false;
                    }

                    department.Cells.Add(new Cell
                    {
                        CellNumber = cell.CellNumber,
                        HasWindow = cell.HasWindow
                    });
                }


                if (department.Cells.Count == 0)
                {
                    depValid = false;
                }

                if (!depValid)
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }
                context.Departments.Add(department);
                output.AppendLine(String.Format(SuccessfullyImportedDepartment, department.Name, department.Cells.Count));
            }
            context.SaveChanges();
            return output.ToString();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            var output = new StringBuilder();
            var prisoners = JsonConvert
                .DeserializeObject<IEnumerable<PrisonersImportModel>>(jsonString);

            foreach (var jsonPrisoner in prisoners)
            {
                if (!IsValid(jsonPrisoner))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime incarcerationDate;

                var isIncarcerationDateValid = DateTime.TryParseExact(jsonPrisoner.IncarcerationDate, "dd/MM/yyyy",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out incarcerationDate);

                if (!isIncarcerationDateValid)
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime? releaseDate = null;
                if (!String.IsNullOrEmpty(jsonPrisoner.ReleaseDate))
                {
                    DateTime releaseDateValue;

                    var isReleaseDateValueValid = DateTime.TryParseExact(jsonPrisoner.IncarcerationDate, "dd/MM/yyyy",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out releaseDateValue);

                    if (!isReleaseDateValueValid)
                    {
                        releaseDate = releaseDateValue;
                    }
                }

                var prisoner = new Prisoner()
                {
                    FullName = jsonPrisoner.FullName,
                    Nickname = jsonPrisoner.Nickname,
                    Age = jsonPrisoner.Age,
                    IncarcerationDate = incarcerationDate,
                    ReleaseDate = releaseDate,
                    Bail = jsonPrisoner.Bail,
                    CellId = jsonPrisoner.CellId,
                };

                bool isMailValid = true;
                foreach (var mail in jsonPrisoner.Mails)
                {
                    if (!IsValid(mail))
                    {
                        isMailValid = false;
                        continue;
                    }

                    prisoner.Mails.Add(new Mail
                    {
                        Description = mail.Description,
                        Sender = mail.Sender,
                        Address = mail.Address
                    });
                }

                if (!isMailValid)
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                context.Prisoners.Add(prisoner);
                output.AppendLine(String.Format(SuccessfullyImportedPrisoner, prisoner.FullName, prisoner.Age));
            }

            context.SaveChanges();
            return output.ToString().TrimEnd();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            var output = new StringBuilder();
            var xmlSerializer = new XmlSerializer(typeof(OfficerXmlImportModel[]),
                new XmlRootAttribute("Officers"));
            var officers = (OfficerXmlImportModel[])xmlSerializer.Deserialize(new StringReader(xmlString));

            foreach (var xmlOfficer in officers)
            {
                if (!IsValid(xmlOfficer))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                object positionObj;
                bool isPositionValid = Enum.TryParse(typeof(Position), xmlOfficer.Position, out positionObj);

                if (!isPositionValid)
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                object weaponObj;
                bool isWeaponValid = Enum.TryParse(typeof(Weapon), xmlOfficer.Weapon, out weaponObj);

                if (!isWeaponValid)
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                var officer = new Officer()
                {
                    FullName = xmlOfficer.FullName,
                    Salary = xmlOfficer.Salary,
                    Position = (Position)positionObj,
                    Weapon = (Weapon)weaponObj,
                    DepartmentId = xmlOfficer.DepartmentId,
                };

                foreach (var prisoner in xmlOfficer.Prisoners)
                {
                    officer.OfficerPrisoners.Add(new OfficerPrisoner()
                    {
                        Officer = officer,
                        PrisonerId = prisoner.PrisonerId,
                    });
                }

                context.Officers.Add(officer);
                output.AppendLine(String.Format(SuccessfullyImportedOfficer, officer.FullName, officer.OfficerPrisoners.Count));
            }

            context.SaveChanges();
            return output.ToString();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
        }
    }
}