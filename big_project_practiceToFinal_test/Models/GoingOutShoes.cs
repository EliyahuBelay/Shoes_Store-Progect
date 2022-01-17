using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace big_project_practiceToFinal_test.Models
{
    public class GoingOutShoes
    {
        int id;
        string companyName;
        string gender;
        Boolean heelOn;
        Boolean ifExist;
        int size;
        int price;

        public int Id { get => id; set => id = value; }
        public string CompanyName { get => companyName; set => companyName = value; }
        public string Gender { get => gender; set => gender = value; }
        public bool HeelOn { get => heelOn; set => heelOn = value; }
        public bool IfExist { get => ifExist; set => ifExist = value; }
        public int Size { get => size; set => size = value; }
        public int Price { get => price; set => price = value; }
    }
}