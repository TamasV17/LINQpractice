namespace LINQgyak
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> prod = new List<Product>();
            DateTime date1 = new DateTime(2023, 4, 18);
            DateTime date2 = new DateTime(2020, 2, 3);
            DateTime date3 = new DateTime(2020, 4, 1);
            DateTime date4 = new DateTime(2021, 5, 8);
            DateTime date5 = new DateTime(2023, 2, 12);
            DateTime date6 = new DateTime(2022, 9, 10);
            DateTime date7 = new DateTime(2022, 1, 4);
            DateTime date8 = new DateTime(2021, 9, 13);
            DateTime date9 = new DateTime(2023, 10, 14);
            DateTime date10 = new DateTime(2019, 10, 24);
            DateTime date11 = new DateTime(2019, 12, 30);
            DateTime date12 = new DateTime(2023, 11, 30);

            Product item1 = new Product("Galaxy S23", "Samsung", 350000, date1, 100);
            Product item2 = new Product("Iphone SE", "Apple", 99999, date2, 66);
            Product item3 = new Product("Iphone SE2", "Apple", 150000, date3, 141);
            Product item4 = new Product("Galaxy S20", "Samsung", 216341, date4, 0);
            Product item5 = new Product("A52", "Samsung", 14722, date5, 15);
            Product item6 = new Product("A72", "Samsung", 18321, date6, 93);
            Product item7 = new Product("Iphone XR", "Apple", 240000, date7, 600);
            Product item8 = new Product("Iphone XS", "Apple", 26125, date8, 124);
            Product item9 = new Product("Iphone 11", "Apple", 311000, date9, 110);
            Product item10 = new Product("Iphone 13 PRO", "Apple", 455000, date10, 302);
            Product item11 = new Product("Flip3", "Samsung", 600001, date11, 99);
            Product item12 = new Product("S21 Ultra", "Samsung", 352677, date12, 15);

            prod.Add(item1);
            prod.Add(item2);
            prod.Add(item3);
            prod.Add(item4);
            prod.Add(item5);
            prod.Add(item6);
            prod.Add(item7);
            prod.Add(item8);
            prod.Add(item9);
            prod.Add(item10);
            prod.Add(item11);
            prod.Add(item12);






            //1)    válogassa le azokat a termékeket amelyek drágábbak mint 300000 Ft
            var moreExpensive = prod.Where(t => t.Price > 300000);


            //2)    válogassa le azokat a termékeket amelyek nevében van ’S’ betű
            var ContainsS = prod.Where(t => t.Name.Contains('S'));


            //3)    válogassa le azokat a termékeket, amelyek ára osztható kettővel maradék
            //nélkül és a bevétel dátuma 2019 - ben volt; majd rendezze márka szerint
            //csökkenő sorrendbe
            var filteredProducts = from x in prod
                                   where x.Price % 2 == 0 && x.DateTime.Year == 2019
                                   orderby x.Brand descending
                                   select x;


            // 4)   számolja meg hány darab "Apple" márkájú termék van
            var apples = prod.Where(t => t.Brand == "Apple").Count();


            //5)    számolja meg hány darab "Samsung" márkájú termék van raktáron (azaz
            //      az egyes termék márkája legyen Samsung és annak a terméknek a darabszáma legalább 1)
            var samsungsOnStock = from x in prod
                                  where x.Brand == "Samsung" && x.AmountOnStock > 0
                                  select x;

            //6)    számolja meg hány darab "Samsung" és "Apple" márkájú termék van
            //együttesen
            var totalProds = (from x in prod
                              where x.Brand == "Samsung" || x.Brand == "Apple"
                              select x).Count();


            //7)    kérje le azokat a termékeket amelyek bevételének ideje 2015-ben volt, és
            //rendezze ezen termékeket raktáron lévő darabszám alapján
            var filteredProducts2 = from x in prod
                                    where x.DateTime.Year == 2015
                                    orderby x.AmountOnStock
                                    select x;

            //8)    értékelje ki, hogy az összes termék ára mennyi, azaz, hogy az aktuális raktárkészlet mekkora értékű
            var totalValue = prod.Sum(t => t.Price * t.AmountOnStock);


            //9)    számoljuk meg, hogy az egyes márkákból hány darab van raktáron
            var countedProds = prod.GroupBy(t => t.Brand).Count();


            //10)   számoljuk meg, hogy az egyes márkákból hány darab van raktáron és mennyi azok márkánkénti átlagára
            var avgPrices = from x in prod
                            group x by x.Brand into g
                            select new
                            {
                                Brand = g.Key,
                                TotalQuantity = g.Sum(t => t.AmountOnStock),
                                AveragePrice = g.Average(t => t.Price)
                            };
        }
    }
}
