namespace E_ATM
{   
     public interface ILogin
    {
        int pinNum { get; set; }
        int cardNum { get; set; }
        int amountOfTries { get; set; }
        //void Registration()  
    } 
    
}