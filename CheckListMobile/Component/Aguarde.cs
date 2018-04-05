using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using CheckListMobile.Active;

namespace CheckListMobile.Component
{
    public static class Aguarde
    {

        static ProgressDialog dialog = null;

        public static void MostraAguarde(bool status, MainActivity parent)
        {
            if (status)
            {
                //DECLARA MENSAGEM ARUARDE
                dialog = null;
                dialog = new ProgressDialog(parent);

                //MENSAGEM DE AGUARDE  
                dialog.Create();
                dialog.SetMessage("AGUARDE");
                dialog.Show();


            }
            else
            {
                //RETIRA A MENSAGEM DE AGUARDE
                if (dialog != null)
                {
                    dialog.Hide();
                    dialog.Dismiss();
                    dialog.Dispose();

                }

            }
        }

        public static void MostraAguarde(bool status, CheckListActivity parent)
        {
            if (status)
            {
                //DECLARA MENSAGEM ARUARDE
                dialog = null;
                dialog = new ProgressDialog(parent);

                //MENSAGEM DE AGUARDE  
                dialog.Create();
                dialog.SetMessage("AGUARDE");
                dialog.Show();


            }
            else
            {
                //RETIRA A MENSAGEM DE AGUARDE
                if (dialog != null)
                {
                    dialog.Hide();
                    dialog.Dismiss();
                    dialog.Dispose();
                }

            }
        }

        public static void MostraAguarde(bool status, FinalizaCheckActivity parent)
        {
            if (status)
            {
                //DECLARA MENSAGEM ARUARDE
                dialog = null;
                dialog = new ProgressDialog(parent);

                //MENSAGEM DE AGUARDE  
                dialog.Create();
                dialog.SetMessage("AGUARDE");
                dialog.Show();


            }
            else
            {
                //RETIRA A MENSAGEM DE AGUARDE
                if (dialog != null)
                {
                    dialog.Hide();
                    dialog.Dismiss();
                    dialog.Dispose();
                }

            }


        }
        public static void MostraAguarde(bool status, CheckChavesActivity parent)
        {
            if (status)
            {
                //DECLARA MENSAGEM ARUARDE
                dialog = null;
                dialog = new ProgressDialog(parent);

                //MENSAGEM DE AGUARDE  
                dialog.Create();
                dialog.SetMessage("AGUARDE");
                dialog.Show();


            }
            else
            {
                //RETIRA A MENSAGEM DE AGUARDE
                if (dialog != null)
                {
                    dialog.Hide();
                    dialog.Dismiss();
                    dialog.Dispose();
                }

            }


        }


        public static void MostraAguarde(bool status, ProblemasActivity parent)
        {
            if (status)
            {
                //DECLARA MENSAGEM ARUARDE
                dialog = null;
                dialog = new ProgressDialog(parent);

                //MENSAGEM DE AGUARDE  
                dialog.Create();
                dialog.SetMessage("AGUARDE");
                dialog.Show();
                
            }
            else
            {
                //RETIRA A MENSAGEM DE AGUARDE
                if (dialog != null)
                {
                    dialog.Hide();
                    dialog.Dismiss();
                    dialog.Dispose();
                }
            }
        }






    }
}