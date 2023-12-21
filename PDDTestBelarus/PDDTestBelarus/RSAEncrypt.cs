using System;
using System.Security.Cryptography;
using System.Text;

namespace PDDTestBelarus;

public class RSAEncryption
{ 
   private  static readonly  string privateKey=
       "<RSAKeyValue>" +
       "<Modulus>1xY/19gJE46QyqHTllS7XIGrb+DgJoRVnLHrbzgEyd/" +
       "DljEBfKON5NHH48B+QYsA6DPcbJwOsDpa2Zf0U56FulSeMPmxl7J21Qwmfw8" +
       "jRkSkEoJ5jumSeuwdCF/MEPg9eVoKik2J6fPOXHPrzPinFsUSva0MhlCdf6TzLHO" +
       "fHId1wd+5OEj7SSuFob1c8oh61Pxw1XZUhtoZviI4gpk4QeuK5FL4eW4CvleH9X2ZhueJs+" +
       "L79rsf4GV2Ubcmf/2mdVjqFQxZg8M1iqkGvMZpiJEGndbEorDd3MQ/IDskcb9omnTqvMGERk" +
       "kWrsCez6L6Y7G12PmJQ6Xy4cauDay7PQ==</Modulus>" +
       "<Exponent>AQAB</Exponent>" +
       "<P>9001Omz28g0eXbsIUhc6Xv+XWZP0f8FgF0o7neHD7Qn3YsyYn6zRZ+Gsp04B6Ffie/NUl/2" +
       "E6xTkgQWIJLfenXZByf3u6ByFZwvc6P0/3lWpNjcJnt7DQK03Lre4Wuaubf6nGnRVeWm1LlgbdoMr" +
       "sb0dhNZsip1DieqGtqpARpc=</P><Q>3qb4DEjzvnB1fhEp3IYEIyKWNtPlcRollAujyH0OhtRmMXe5" +
       "pyjYCMX8puAZMbpsNOnPQh5rNbKPCuNkv08zrVpZMBA42Eqi2vuDtOhXMU++2y6TaG6twfpil32C2Fg" +
       "yWpXOhuNtix20MlCf2lurEusx8qiskmp5YiLuZtuu+0s=</Q><DP>TSb7OjUQfcd198wH9oRko4qdz0aHeuv7" +
       "bIiuPL1YgLUhRuOJohcqZXxUfwWpNrFkaUMq2xguxaCJAW+WX841V26za68bP7LWM6XRz6ZirJyQ4+cby0K4K49ereaHT2S0eoB9" +
       "5ZTxraU67zBxsPGPSi4z7WNwDXauwXI3gPlwgBU=</DP><DQ>TBuC+qANQXGrl9ZCGvFshJ4T/tXbvheT9NEtwSCOUKRV8l7chTk+" +
       "73DN9jTwJ8Fzr3qksBM5znck0jH8hDCMl5sklXtWEwkgNf53fOVWuLJrqPx4wt/iYUY3YVUz3sP3ImPG3vDqxvz2VaSdn8Rp6+Odh" +
       "TcHFl1y9IrAN0SswZU=</DQ><InverseQ>W2tGORcvXhVMgxnjyH+Uc7wcIChfFQZrRNGAvQK0ZC2Hz39SjzV/8F1GljchCPJXQoGr" +
       "EW43zrVXfWC+fHGsTAjUL7DcNxBMeS6UxKkKHK9clQ2TMIKIhlK7J5OkgHFzcvFBGQEiUuMqSMPv6cACdByNQ4csY6Ha2W4NwzK3NO4" +
       "=</InverseQ><D>FlH/xBVuM7Jawjxy6anXW601LkIG4NhgzgcEqKEGljB7ao2hWt7aLcG7XZ4vO/wB1xbyq+6x84XKwcPsHfVYaVK4q9" +
       "ptnJFvlYJSSGM4xOUApc8WcEc65Ti1dpYCZkxsjLhUWa/cPQQJCT0aXkX7iPhgjoBzyUh6X7GtbpJ9E4emYsE+8tp4JpKRlFCCOWWYwm2Hir" +
       "hs+22im307s2zAGpiz3DzWMmmGw4XHBzLoiSAHeJmTGNJyEJOiQMekiEncU8dGLmDwprBJzvjnsFUAnfs1H2WWiU88H1NOAw0WabICpzyr0Cg" +
       "894DdsdhBE1kNxmlWkRsiAEGZbNUeC4gVHQ==</D></RSAKeyValue>";

    public static string Decrypt(string encryptedMessage)
    {
        byte[] encryptedData = Convert.FromBase64String(encryptedMessage);

        using (var rsa = new RSACryptoServiceProvider())
        {
            rsa.FromXmlString(privateKey);
            byte[] decryptedData = rsa.Decrypt(encryptedData, true);
            return Encoding.UTF8.GetString(decryptedData);
        }
    }
}