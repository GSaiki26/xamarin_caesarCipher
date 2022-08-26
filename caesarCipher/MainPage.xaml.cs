using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace caesarCipher {
    public partial class MainPage : ContentPage {

        private readonly string alphabet = "abcdefghijklmnopqrstuvwxyz";

        public MainPage() {
            InitializeComponent();
        }

        private void ButtonConverter_Clicked(object sender, EventArgs e) {
            // Check if the entry has some text.
            if (entryInput.Text == "") {
                labelError.Text = "Por favor escreva algum texto no input abaixo.";
                return;
            }
            labelError.Text = "";
            this.ClearGrid();

            // Convert the string and get all the array.
            string[] convertedText = this.GetCaesarCipher(entryInput.Text);
            this.InsertIntoGrid(convertedText);
        }

        private string[] GetCaesarCipher(string textToConvert) {
            string[] convertedText = new string[26];

            for (int jumps = 1; jumps < this.alphabet.Length; jumps++) {
                convertedText[jumps] = this.ConvertText(textToConvert, jumps);
            }
            return convertedText;
        }

        private string ConvertText(string text, int jumps) {
            string formattedText = "";
            text = text.ToLower();

            for (int i = 0; i < text.Length; i++) {
                char character = text[i];
                int positionInAlpha = this.alphabet.IndexOf(character);
                if (positionInAlpha == -1) {
                    formattedText += character;
                    continue;
                }
                
                positionInAlpha += jumps;
                
                // Check if the current position has ultrepassed the alphabet length.
                if (positionInAlpha > this.alphabet.Length - 1) {
                    positionInAlpha -= this.alphabet.Length;
                }

                formattedText += this.alphabet[positionInAlpha];
            }

            return formattedText;
        }

        private void InsertIntoGrid(string[] convertedText) {
            for (int jumps = 1; jumps < convertedText.Length; jumps++) {
                gridMain.Children.Add(new Label { Text = $"{jumps}"}, 0, jumps);
                gridMain.Children.Add(new Label { Text = convertedText[jumps] }, 1, jumps);
            }
        }

        private void ClearGrid() {
            gridMain.Children.Clear();
        }
    }
}
