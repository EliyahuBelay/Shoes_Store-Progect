using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace big_project_practiceToFinal_test.Models
{
    public class Shoes
    {
        int id;
        string nameCompany;
        string nameModel;
        int size;
        int price;

        public Shoes(int id, string nameCompany, string nameModel, int size, int price)
        {
            Id = id;
            NameCompany = nameCompany;
            NameModel = nameModel;
            Size = size;
            Price = price;
        }

        public int Id { get => id; set => id = value; }
        public string NameCompany { get => nameCompany; set => nameCompany = value; }
        public string NameModel { get => nameModel; set => nameModel = value; }
        public int Size { get => size; set => size = value; }
        public int Price { get => price; set => price = value; }
    }
}