using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JsonMapAdd
{
    public partial class Interface : Form
    {

        public Interface()
        {
            InitializeComponent();
            foreach(var tipo in MappingData.Type)
            {
                tipoBuscaTxt.Items.Add(tipo.Value);
            }
        }

        private void Interface_Load(object sender, EventArgs e)
        {

        }

        private void filtroLabel_Click(object sender, EventArgs e)
        {
            enableAddButton();

        }

        private void AddBtn_Click(object sender, EventArgs e)
        {

            List<string> filtro = new List<string> { filterOneTxt.Text, filterTwoTxt.Text };
            List<MappingData> dadosList = JsonThings.MappingJsonRead();
            MappingData newMap = new MappingData
            {
                Tipo = tipoBuscaTxt.SelectedIndex + 1,
                Filtro = filtro,
                Chave = keyText.Text,
                Mudar = changeText.Text,
            };
            dadosList.Add(newMap);
            JsonThings.OverrideJson(dadosList);

        }

        private void JsonList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void attBtn_Click(object sender, EventArgs e)
        {
            JsonList.Items.Clear();
            foreach (var dado in JsonThings.MappingJsonRead())
            {
                JsonList.Items.Add($"Filtro:  {dado.Filtro[0]}, {dado.Filtro[1]}");
            }
        }

        private void tipoBuscaTxt_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Verifica se o tipo é direct, pois no direct não tem Chave
            if (tipoBuscaTxt.SelectedIndex + 1 == 4) {
                changeText.Text = "NOTHING";
                changeText.Enabled = false;
            }
            else { changeText.Enabled = true;}
            enableAddButton();
        }
        private void enableAddButton() {
            if (changeText.Text.Length > 0 || keyText.Text.Length > 0 || filterOneTxt.Text.Length > 0 || tipoBuscaTxt.SelectedIndex != -1)
            {
                AddBtn.Enabled = true;
            }
            else AddBtn.Enabled = false;
        }

        private void changeText_TextChanged(object sender, EventArgs e)
        {
            enableAddButton();

        }

        private void keyText_TextChanged(object sender, EventArgs e)
        {
            enableAddButton();

        }

        private void filterOneTxt_TextChanged(object sender, EventArgs e)
        {
            enableAddButton();
            if (filterOneTxt.Text.Length <= 0) { filterTwoTxt.Enabled = false; filterTwoTxt.Text = null; }
            else { filterTwoTxt.Enabled = true; }
        }

        private void slctRmvBtn_Click(object sender, EventArgs e)
        {
            List<MappingData> dadosList = JsonThings.MappingJsonRead();
            foreach (int index in JsonList.CheckedIndices)
            {
                dadosList.RemoveAt(index);
            };
            JsonThings.OverrideJson(dadosList);
            JsonList.Items.Clear();
            foreach (var dado in JsonThings.MappingJsonRead())
            {
                JsonList.Items.Add($"Filtro:  {dado.Filtro[0]}, {dado.Filtro[1]}");
            }
        }
    }
}
