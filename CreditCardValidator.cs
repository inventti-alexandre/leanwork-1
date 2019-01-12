using System;

public class CreditCardValidator
{
	public static void Main()
	{
    string cc = "4111111111111111";

		if(CreditCardValidator.isValidCard(cc)){
			Console.Write(" válido");
		}else{
			Console.WriteLine(" inválido");
		}
	}
	
	public static bool isValidCard(String cc)
	{
    cc = cc.Replace(" ", string.Empty);

		// Check if cc flag is valid
		if(!CreditCardValidator.isValidFlag(cc))
			return false;

		int sum = 0;
		char[] reverseCC = cc.ToCharArray();
    Array.Reverse(reverseCC);

		for (int i = 0; i < reverseCC.Length; i++)
		{
			if (i % 2 == 0){
				sum += Convert.ToInt16(reverseCC[i].ToString());
			}else{
				int newValue = (int)(Convert.ToInt16((reverseCC[i].ToString())) * 2);
				sum += Convert.ToInt16((newValue > 9 ? (newValue - 9) : newValue).ToString());
			}
		}

		if ((sum % 10) == 0)
			return true;
		else
			return false;
	}

	public static bool isValidFlag(string cc){
		// Amex
		if ((cc.Substring(0, 2).Equals("34") || cc.Substring(0, 2).Equals("37"))){
			if(cc.Length.Equals(15)){
        Console.Write("Amex: " + cc);
        return true;
      }
		}

		// Discover
		if (cc.Substring(0, 4).Equals("6011")){
			if(cc.Length.Equals(16)){
        Console.Write("Discover: " + cc);
        return true;
      }
		}

		// MasterCard
		if ((Convert.ToInt16(cc.Substring(0, 2)) >= 51) && (Convert.ToInt16(cc.Substring(0, 2)) <= 55)){
			if(cc.Length.Equals(16)){
        Console.Write("MasterCard: " + cc);
        return true;
      }
		}

		// Visa
		if (cc.Substring(0, 1).Equals("4")){
			if(cc.Length.Equals(16) || cc.Length.Equals(13)){
        Console.Write("Visa: " + cc);
        return true;
      }
		}

		return false;
	}
}
