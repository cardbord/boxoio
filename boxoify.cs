namespace boxoio;

class Vigenere {
     

     static string Keycircle(string key, int len_text) {
          if (len_text < key.Length) {
               return key.Substring(0, len_text).ToUpper();
          }
          string circled_key = "";
          for (int i = 0; i < key.Length; i++) {
               circled_key += key;
          }
          if (circled_key.Length > len_text) {
               circled_key = circled_key.Substring(0, len_text);
          }
          Console.WriteLine(circled_key.Length);
          Console.WriteLine(len_text);
          return circled_key.ToUpper();
     }

     public static string Encode(string text, string key) {
          text=text.ToUpper();
          string ciphertext = "";
          key = Keycircle(key, text.Length);
          string alpha = "abcdefghijklmnopqrstuvwxyz";
          for (int i = 0; i < text.Length; i++) {
               if (text[i] != ' ') {
                    int ac = (int)text[i];
                    int cd = (int)key[i];
                    ciphertext += alpha[(ac+cd)%26];
               }
               else  {
                    ciphertext += text[i];
               }
          }

          return ciphertext.ToUpper();
     }

     public static string Decode(string ciphertext, string key) {
          string plaintext="";
          key = Keycircle(key, ciphertext.Length);
          string alpha = "abcdefghijklmnopqrstuvwxyz";
          for (int i = 0; i < ciphertext.Length; i++) {
               if (ciphertext[i] != ' ') {
                    int ac = (int)ciphertext[i];
                    int cd = (int)key[i];
                    plaintext += alpha[(ac-(cd%26))%26];
               }
               else {
                    plaintext += ciphertext[i];
               }
          }
          return plaintext;
     }
}