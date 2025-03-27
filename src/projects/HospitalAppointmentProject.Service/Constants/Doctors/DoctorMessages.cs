using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalAppointmentProject.Service.Constants.Doctors
{
    public static class DoctorMessages
    {
        public const string DoctorNameMustBeUnniqueMessage = "Doktor Adı Benzersiz Olmalıdır";
        public const string DoctorAddedMessage = "Doktor Eklendi";
        public const string DoctorNotFoundMessage = "Doktor Bulunamadı";
        public const string CheckDoctorLimitAsync = "Bir Hastanede Aynı Branş da En Fazla 2 Doktor Olabilir.";

    }
}
