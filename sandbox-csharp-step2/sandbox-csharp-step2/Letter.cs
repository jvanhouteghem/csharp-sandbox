using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sandbox_csharp_step2 {

    class Letter {

        int nbColumn = 50;
        int nbLine = 30;

        Random random = new Random();

        // Alphabet
        public String[] alphabet = { " ", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "&", "?" };

        // RandomLetter
        public String getRandomLetterFromAlphabet() {
            int position = random.Next(0, alphabet.Length);
            return alphabet[position];
        }

        // Création d'un mot aléatoire, il faudra autant de mots que de colonnes
        public String generateRandomWord() {
            //System.Threading.Thread.Sleep(35);
            String result = "";

            for (int i = 0; i < 100; i++) {
                result += getRandomLetterFromAlphabet();
            }

            return result;
        }



    }
}
