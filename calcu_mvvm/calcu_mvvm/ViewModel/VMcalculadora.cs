using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace calcu_mvvm.ViewModel
{
    public class VMcalculadora : BaseViewModel
    {
        #region VARIABLES
        private decimal primerNumero;
        private string resultado;
        private bool clickedOperador;
        private string operador;
        private string operadorSeleccionado;

        #endregion
        #region OBJETOS
        //private bool _isButtonClicked;
        //public bool IsButtonClicked
        //{
        //    get { return _isButtonClicked; }
        //    set
        //    {
        //        if (_isButtonClicked != value)
        //        {
        //            _isButtonClicked = value;
        //            OnPropertyChanged(nameof(IsButtonClicked));
        //        }
        //    }
        //}
        public string Resultado
        {
            get { return resultado; } 
            set { SetValue(ref resultado, value);}
        }
        public string Operador
        {
            get { return operador; }
            set { SetValue(ref operador, value); }
        }
        #endregion
        #region PROCESOS

        public ICommand ClearCommand => new Command(Clear);
        public void Clear()
        {
            Resultado = "0";
            clickedOperador = false;
            primerNumero = 0;
        }
        public ICommand BtnXCommand => new Command(BtnX);
        public void BtnX()
        {
            string number = Resultado;
            if (number != "0")
            {
                number = number.Remove(number.Length - 1, 1);
                if (string.IsNullOrEmpty(number))
                {
                    Resultado = "0";
                }
                else
                {
                   Resultado = number;
                }
            }
        }
        public ICommand BtnPorcentajeCommand => new Command(BtnPorcentaje);
        public void BtnPorcentaje()
        {
            try
            {
                string number = Resultado;
                if (number != "0")
                {
                    decimal percentValue = Convert.ToDecimal(number);
                    string result = (percentValue / 100).ToString("0.##");
                    Resultado = result;
                }
            }
            catch (Exception ex)
            {
                //await DisplayAlert("Error", ex.Message, "Ok");
            }
        }
        public ICommand BtnDivCommand => new Command(() => BtnOperacion("÷"));
        public ICommand BtnMultCommand => new Command(() => BtnOperacion("X"));
        public ICommand BtnRestaCommand => new Command(() => BtnOperacion("-"));
        public ICommand BtnSumCommand => new Command(() => BtnOperacion("+"));
        public ICommand BtnIguallCommand => new Command(BtnIgual);
        public void BtnIgual()
        {
            try
            {
                decimal segundoNuemero = Convert.ToDecimal(Resultado);
                string resultadoFinal = Calculate(primerNumero, segundoNuemero).ToString("0.##");
                Resultado = resultadoFinal;
            }
            catch (Exception ex)
            {
                //DisplayAlert("Error", ex.Message, "Ok");
            }

        }

        public decimal Calculate(decimal primerNumero, decimal segundoNumero)
        {
            decimal result = 0;
            if (operador == "+")
            {
                result = primerNumero += segundoNumero;
            }
            else if (operador == "-")
            {
                result = primerNumero -= segundoNumero;
            }
            else if (operador == "X")
            {
                result = primerNumero *= segundoNumero;
            }
            else if (operador == "÷")
            {
                result = primerNumero /= segundoNumero;
            }
            return result;
        }
        public void BtnOperacion(string operacion)
        {
            //IsButtonClicked = true;
            clickedOperador = true;
            operador = operacion;
            primerNumero = Convert.ToDecimal(Resultado);
        }
       
        public ICommand BtnUnoCommand => new Command(() => ExecuteButtonCommand("1"));
        public ICommand BtnDosCommand => new Command(() => ExecuteButtonCommand("2"));
        public ICommand BtnTresCommand => new Command(() => ExecuteButtonCommand("3"));
        public ICommand BtnCuatroCommand => new Command(() => ExecuteButtonCommand("4"));
        public ICommand BtnCincoCommand => new Command(() => ExecuteButtonCommand("5"));
        public ICommand BtnSeisCommand => new Command(() => ExecuteButtonCommand("6"));
        public ICommand BtnSieteCommand => new Command(() => ExecuteButtonCommand("7"));
        public ICommand BtnOchoCommand => new Command(() => ExecuteButtonCommand("8"));
        public ICommand BtnNueveCommand => new Command(() => ExecuteButtonCommand("9"));
        public ICommand BtnCeroCommand => new Command(() => ExecuteButtonCommand("0"));
        public ICommand BtnPuntoCommand => new Command(() => ExecuteButtonCommand("."));
        public void ExecuteButtonCommand(string buttonText)
        {
           
            // Verificar si el botón presionado es un punto decimal
            if (buttonText == ".")
            {
                // Verificar si el número actual ya contiene un punto 
                if (!Resultado.Contains("."))
                {
                    // Si no contiene un punto, agregarlo al número actual
                    Resultado += buttonText;
                }
            }
            else
            {
                // Si el botón no es un punto decimal, manejar la lógica normal para números
                if (Resultado == "0" || clickedOperador)
                {
                    clickedOperador = false;
                    Resultado = buttonText;
                }
                else
                {
                    Resultado += buttonText;
                }
            }
        }
        #endregion
    }

}
