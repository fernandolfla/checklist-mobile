
using Android.App;
using Android.OS;
using Android.Text;
using Android.Views;
using Android.Widget;
using CheckListMobile.Component;
using CheckVTR.BLL;
using CheckVTR.Seguranca;
using System.Threading.Tasks;
using static Android.Views.ViewGroup;


namespace CheckListMobile.Active
{
    [Activity(Label = "FinalizaCheck")]
    public class FinalizaCheckActivity : Activity
    {

        public FinalizaCheckActivity parent;
       // static ProgressDialog dialog = null;
        bool certo = false;
        CheckListBLL BLL = new CheckListBLL();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            //PARAMETROS PARA OS INTENS
            LayoutParams lp = new LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
            LayoutParams lpL = new LayoutParams(ViewGroup.LayoutParams.WrapContent, ViewGroup.LayoutParams.WrapContent);
            LayoutParams person = new LayoutParams(LayoutParams.MatchParent, 240);
            lp.Height = 200;

            //LAYOUT PRINCIPAL QUE IRÀ DENTRO DO SCROLL
            LinearLayout layout = new LinearLayout(this);
            layout.Orientation = Orientation.Vertical;
            layout.LayoutParameters = lpL;
            //SCROLL DE ROLAGEM
            ScrollView scroll = new ScrollView(this);
            scroll.LayoutParameters = lpL;
            this.SetContentView(scroll);
            scroll.AddView(layout);
           
            
            TextView lblChaves = new TextView(this);
            lblChaves.Text = "Encerre seu CHECKLIST  Sr. " + Autenticacao.GetApelido()  + "\n Digite o KM Final";
            lblChaves.SetTextSize(Android.Util.ComplexUnitType.Sp, 30);


            Button botao = new Button(this);
            botao.Text = "CONCLUIR";


            EditText km = new EditText(this);
            km.SetMaxLines(1);
            km.InputType = Android.Text.InputTypes.ClassNumber;
            km.SetTextSize(Android.Util.ComplexUnitType.Sp, 60);
            //MAX LENGHT
            km.SetFilters(new IInputFilter[] { new InputFilterLengthFilter(5) });



            TextView lblObs = new TextView(this);
            lblObs.Text = "Observações Finais";
            lblObs.SetTextSize(Android.Util.ComplexUnitType.Sp, 30);


            EditText obs2 = new EditText(this);
            obs2.SetMaxLines(4);
            obs2.SetTextSize(Android.Util.ComplexUnitType.Sp, 40);
            obs2.Text = "Plantão S.A.";
            obs2.SetFilters(new IInputFilter[] { new InputFilterLengthFilter(999) });

            Switch problema = new Switch(this);
            problema.Text = "Transformar em Problema";
            problema.SetTextColor(Android.Graphics.Color.Red);
            problema.SetTextSize(Android.Util.ComplexUnitType.Sp, 24);


            layout.AddView(lblChaves, lp);
            layout.AddView(km, lp);
            layout.AddView(lblObs, lp);
            layout.AddView(obs2, lp);
            layout.AddView(problema, lp);
            layout.AddView(botao, person);


            botao.Click += delegate {



                //
                Aguarde.MostraAguarde(true,this);
                var task = Task.Factory.StartNew(() =>
                {                    
                    certo = BLL.Cadastra_Finaliza(km.Text, obs2.Text, problema.Checked);

                });
                task.ContinueWith(
                 t =>
                 {
                     if (certo)
                     {
                         Toast.MakeText(this, "CHECKLIST FINALIZADO", ToastLength.Long).Show();
                         this.FinishAffinity();
                     }
                     else
                         Toast.MakeText(this, "VERIFIQUE OS CAMPOS OBRIGATÓRIOS", ToastLength.Long).Show();
                     Aguarde.MostraAguarde(false, this);
                 }, TaskScheduler.FromCurrentSynchronizationContext());

                //


               


            };



        }

        //static void MostraAguarde(bool status, FinalizaCheck parent)
        //{
        //    if (status)
        //    {
        //        //DECLARA MENSAGEM ARUARDE
        //        if (dialog == null)
        //            dialog = new ProgressDialog(parent);

        //        //MENSAGEM DE AGUARDE  
        //        dialog.SetMessage("AGUARDE");

        //        dialog.Show();

        //    }
        //    else
        //    {
        //        //RETIRA A MENSAGEM DE AGUARDE
        //        if (dialog != null)
        //            dialog.Hide();
        //    }

            
        //}
    }
}