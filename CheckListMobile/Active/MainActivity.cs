using Android.App;
using Android.Content;
using Android.Widget;
using Android.OS;
using CheckVTR.BLL;
using Android.Views.InputMethods;
using System.Threading.Tasks;
using CheckListMobile.Active;
using CheckListMobile.Component;

namespace CheckListMobile
{
    [Activity(Label = "CheckList  Mobile by JURUSEG", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        //METODO PARA ABAIXAR TECLADO DEPOIS DE LOGAR
        private InputMethodManager imm;

        public MainActivity parent;
        //static ProgressDialog dialog = null;
        static int resultado = 5;


        private int Logar()
        {     
            LoginBLL BLL = new LoginBLL();

            var user = FindViewById<EditText>(Resource.Id.Usuario);
            var password = FindViewById<EditText>(Resource.Id.Senha);

            //FUNÇÃO PARA BUSCAR NO BANCO USUARIO E SENHA E COMPARAR
            int result = BLL.Logar(user.Text, password.Text);

            //ABAIXA O TECLADO DEPOIS DE LOGAR
            imm.HideSoftInputFromWindow(user.WindowToken, 0);
            imm.HideSoftInputFromWindow(password.WindowToken, 0);

            return result;
        }

        protected override void OnCreate(Bundle bundle)
        {        
            base.OnCreate(bundle);
            // Set our view from the "main" layout resource
            //SETA O LAYOUT INICIAL PARA VISUALIZAÇÃO
            SetContentView(Resource.Layout.Main);
            //INSTANCIA O BOTÃO E PEGA SUA ID
            Button btnLogin = FindViewById<Button>(Resource.Id.BtnLogin);
            
            //EFEITO APÓS O CLICK DO BOTÃO
            btnLogin.Click += delegate {

                
                Aguarde.MostraAguarde(true, this);

                var task = Task.Factory.StartNew(() =>
                {
                    resultado = Logar();
                    

                });
                task.ContinueWith(
                t =>
                {
                    Aguarde.MostraAguarde(false, this);
                    switch (resultado)
                    {
                        case 1: resultado = 5;
                            //PASSAGEM PARA PROXIMO LAYOUT
                            var activity2 = new Intent(this, typeof(InicioActivity));
                            //activity2.PutExtra("parametro1", edt.Text);   // PARAMETROS ENTRE TELAS
                            StartActivity(activity2);

                            break;
                        case 2:
                            Toast.MakeText(this, "Usuário ou senha Inválida", ToastLength.Long).Show();
                            break;
                        case 3:
                            Toast.MakeText(this, "Usuário ou senha Inválida", ToastLength.Long).Show();
                            break;
                        case 4:
                            Toast.MakeText(this, "Usuário ou senha Inválida", ToastLength.Long).Show();
                            break;
                        default:
                            Toast.MakeText(this, "FALHA AO LOGAR", ToastLength.Long).Show();
                            break;
                    }
                  

                }, TaskScheduler.FromCurrentSynchronizationContext());

               
                //MostraAguarde(false, this);
                
            }; // FINAL DA AÇÃO DO BOTÃO
                     
            //METODO DE ABAIXAR O TECLADO DEPOIS DE LOGAR
            imm = (InputMethodManager)GetSystemService(Context.InputMethodService);

            //INICIO DA TELA CHECKLIST






        }

        //static void MostraAguarde(bool status, MainActivity parent)
        //{
        //    if (status)
        //    {
        //        //DECLARA MENSAGEM ARUARDE
        //        if(dialog == null)
        //            dialog = new ProgressDialog(parent);

        //        //MENSAGEM DE AGUARDE  
        //        dialog.SetMessage("AGUARDE");

        //        dialog.Show();

        //    }
        //    else {
        //        //RETIRA A MENSAGEM DE AGUARDE
        //        if(dialog != null)
        //            dialog.Hide();
        //    }            
        //}








    }
}

