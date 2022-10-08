/* Örnek 1
int sayi1 = 10;
int sayi2 = 20;
sayi1 = sayi2;
sayi2 = 100;
Console.WriteLine(sayi1);
*/

/* Örnek 2 
int[] sayilar1 = new[] { 1, 2, 3 };
int[] sayilar2 = new[] { 10, 20, 30};
sayilar1 = sayilar2;
sayilar2[0] = 1000;

Console.WriteLine(sayilar1[0]);
*/
class Program
{
    static void Main(string[] args)
    {/*
        CreditMenager creditMenager = new CreditMenager();
        creditMenager.Save();
        Customer customer = new Customer();
        customer.Id = 1;
        customer.City = "Kırklareli";

        CustomerMenager customerMenager = new CustomerMenager(customer);
        customerMenager.Save();
        customerMenager.Delete();
       
        CustomerMenager customerMenager1 = new CustomerMenager(new Company());

        
        Person person = new Person();
        person.FirstName = "Onur";
        person.LastName = "Yeşiltaş";
        person.NationalIdentity = "12345678998";

        Customer customer1 = new Customer();
        Customer customer2 = new Person();
        Customer customer3 = new Company();   

        Company company = new Company();
        company.Id = 2;
        company.CompanyName = "Arçelik";
        company.TaxNumber = "12336";
        */

        CustomerMenager customerMenager = new CustomerMenager(new Customer(), new CarCreditMenager());
        customerMenager.GiveCredit();
    }
}

class CreditMenager
{
    public void Calculate()
    {
        Console.WriteLine("Hesaplandı.");

    }
    public void Save()
    {
        Console.WriteLine("Kredi verildi.");

    }
}
interface ICreditMenager
{
    void Calculate();
    void Save();

}
abstract class BaseCreditMenager : ICreditMenager
{
    public abstract void Calculate();
    public virtual void Save()
    {
        Console.WriteLine("Kaydedildi");
    }
}
class TeacherCreditMenager :BaseCreditMenager, ICreditMenager
{
    public override void Calculate()
    {
        Console.WriteLine("Öğretmen Kredisi Hesaplandı");
    }
    public override void Save()
    {

        base.Save();
    }

}
class CarCreditMenager :BaseCreditMenager, ICreditMenager
{
    public override void Calculate()
    {
        Console.WriteLine("Araba Kredisi Hesaplandı");
    }
}
class MilitaryCreditMenager : BaseCreditMenager, ICreditMenager
{
    public override void Calculate()
    {
        Console.WriteLine("Asker Kredisi Hesaplandı");
    }
}
class Customer
{
    public Customer()
    {
        Console.WriteLine("Müşteri Nesnesi Başlatıldı.");
    }


    public int Id;

    public string City { get; set; }

}
class Person:Customer
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string NationalIdentity { get; set; }
    
}
class Company:Customer
{
    public string CompanyName { get; set; }
    public string TaxNumber { get; set; }
    
}
class CustomerMenager
{
    private Customer _customer;
    private ICreditMenager _creditMenager;
    public CustomerMenager(Customer customer , ICreditMenager creditMenager)
    {
        _customer = customer;
        _creditMenager = creditMenager;

    }
    public void Save()
    {
        Console.WriteLine("Müşteri Eklendi: " + _customer.Id);
    }
    public void Delete()
    {
        Console.WriteLine("Müşteri Silindi: " + _customer.Id);
    }
    public void GiveCredit()
    {
        _creditMenager.Calculate();
        Console.WriteLine("Kredis Hesaplandı");

    }
}