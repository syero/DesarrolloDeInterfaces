using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace PonerControles
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        List<String> PalabrasSugeridas = new List<string>();
        /** Todos estos metodos son para el AutoSuggestBox que tengo en el xaml   */
        private void AutoSuggestBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            // Only get results when it was a user typing,
            // otherwise assume the value got filled in by TextMemberPath
            // or the handler for SuggestionChosen.
            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                
                List<String> palabras = new List<string>();

                palabras.Add("Estofado");
                palabras.Add("Marinero");
                palabras.Add("Camino");
                palabras.Add("Rucula");
                palabras.Add("Puerta");
                palabras.Add("Quinto");
                palabras.Add("Dorado");
                palabras.Add("Casa");
                palabras.Add("Destructor");
                palabras.Add("Intento");

                PalabrasSugeridas = palabras.Where(palabraBuscada => palabraBuscada.StartsWith(sender.Text)).ToList();
                sender.ItemsSource=PalabrasSugeridas;
            }
        }


        private void AutoSuggestBox_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            // Set sender.Text. You can use args.SelectedItem to build your text string.
            var valorSeleccionado = args.SelectedItem.ToString();
            sender.Text = valorSeleccionado;

        }


        private void AutoSuggestBox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            if (args.ChosenSuggestion != null)
            {
                // User selected an item from the suggestion list, take an action on it here.
                sender.Text = args.ChosenSuggestion.ToString();
            }
            else
            {
                // Use args.QueryText to determine what to do.
                
            }
        }//fin

        private void ToggleSwitch_Toggled(object sender, RoutedEventArgs e)
        {

        }

        /** Aqui termina todos los metodos que son para el AutoSuggestBox que tengo en el xaml   */


        private void HandleCheck(object sender, RoutedEventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            if (cb.Name == "cb1") text1.Text = "Two-state CheckBox checked.";
            else text2.Text = "Three-state CheckBox checked.";
        }

        private void HandleUnchecked(object sender, RoutedEventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            if (cb.Name == "cb1") text1.Text = "Two-state CheckBox unchecked.";
            else text2.Text = "Three-state CheckBox unchecked.";
        }

        private void HandleThirdState(object sender, RoutedEventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            text2.Text = "Three-state CheckBox indeterminate.";
        }

        private void c_DataPickerDeperture_DateChanged(CalendarDatePicker sender, CalendarDatePickerDateChangedEventArgs args)
        {

        }

        private void c_DataPickerArrival_DateChanged(CalendarDatePicker sender, CalendarDatePickerDateChangedEventArgs args)
        {

        }
    }
}
