using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace big_project_practiceToFinal_test.Models
{
    public class SportShoes
    {
        int id;
        string companyName;
        string modelShoes;
        int size;
        int price;

        public SportShoes() { }
        public SportShoes(int id, string companyName, string modelShoes, int size, int price)
        {
            Id = id;
            CompanyName = companyName;
            ModelShoes = modelShoes;
            Size = size;
            Price = price;
        }

        public int Id { get => id; set => id = value; }
        public string CompanyName { get => companyName; set => companyName = value; }
        public string ModelShoes { get => modelShoes; set => modelShoes = value; }
        public int Size { get => size; set => size = value; }
        public int Price { get => price; set => price = value; }
    }
}