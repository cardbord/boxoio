namespace boxoio;

//conv from alpha base str -> ascii: + 65

class Vigenere {
     

     static string Keycircle(string key, int len_text) {
          if (len_text < key.Length) {
               return key.Substring(0, len_text).ToUpper();
          }
          string circled_key = "";
          for (int i = 0; i < len_text; i++) {
               circled_key += key;
          }
          if (circled_key.Length > len_text) {
               circled_key = circled_key.Substring(0, len_text);
          }
          
          return circled_key.ToUpper();
     }

     public static string Encode(string text, string key) {
          
          string ciphertext = "";
          key = Keycircle(key, text.Length);
          
          for (int i = 0; i < text.Length; i++) {

               if (text[i] != ' ' & char.IsAsciiLetter(text[i])) {
                    
                    char a_temp = text[i];
                    int ac = (int)char.ToUpper(a_temp); //nasty!
                    int cd = (int)key[i];
                    
                    int bc = (ac+cd)%26;
                    
                    char to_add = Convert.ToChar(bc + 65); //converts to uppercase ascii

                    if (char.IsUpper(text[i])==true) {
                         ciphertext+=to_add;
                    }
                    else {
                         ciphertext+=char.ToLower(to_add); //to add case sensitivity
                    }

                    
               }
               else  {
                    ciphertext += text[i]; //spaces ignored
               }
          }

          return ciphertext;
     }

     public static string Decode(string ciphertext, string key) {
          string plaintext="";
          key = Keycircle(key, ciphertext.Length);
          
          for (int i = 0; i < ciphertext.Length; i++) {
               if (ciphertext[i] != ' ' && char.IsAsciiLetter(ciphertext[i])) {
                    char a_temp = ciphertext[i];
                    int ac = (int)char.ToUpper(a_temp);
                    int cd = (int)key[i];
                    
                    char to_add = Convert.ToChar((ac-(cd%26))%26 + 65); //converts back to upper on defuals
               
                    if (char.IsUpper(ciphertext[i])==true) {
                         plaintext+=to_add;
                    }
                    else {
                         plaintext+=char.ToLower(to_add);
                    }

               }
               else {
                    plaintext += ciphertext[i];
               }
          }
          return plaintext;
     }
}