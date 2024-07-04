using Newtonsoft.Json;
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
        #region INTERFACE
        public Interface()
        {
            InitializeComponent();
            foreach(var tipo in MappingData.Type)
            {
                tipoBuscaTxt.Items.Add(tipo.Value);
            }
        }

        private void filtroLabel_Click(object sender, EventArgs e)
        {
            enableAddButton();
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {

            List<string> filtro = new List<string> { filterOneTxt.Text, filterTwoTxt.Text };
            List<MappingData> dadosList = MappingJsonRead();
            MappingData newMap = new MappingData
            {
                Tipo = tipoBuscaTxt.SelectedIndex + 1,
                Filtro = filtro,
                Chave = keyText.Text,
                Mudar = changeText.Text,
            };
            dadosList.Add(newMap);
            OverrideJson(dadosList);

        }

        private void attBtn_Click(object sender, EventArgs e)
        {
            JsonList.Items.Clear();
            foreach (var dado in MappingJsonRead())
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
            List<MappingData> dadosList = MappingJsonRead();
            foreach (int index in JsonList.CheckedIndices)
            {
                dadosList.RemoveAt(index);
            };
            OverrideJson(dadosList);
            JsonList.Items.Clear();
            foreach (var dado in MappingJsonRead())
            {
                JsonList.Items.Add($"Filtro:  {dado.Filtro[0]}, {dado.Filtro[1]}");
            }
        }
        #endregion
        
        #region METODOS AUXILIARES

        /// <summary>
        /// Metodo para garantir que o botão de adicionar só seja habilitado na hora certa.
        /// </summary>
        private void enableAddButton()
        {
            if (changeText.Text.Length > 0 && keyText.Text.Length > 0 && filterOneTxt.Text.Length > 0 && tipoBuscaTxt.SelectedIndex != -1)
            {
                AddBtn.Enabled = true;
            }
            else AddBtn.Enabled = false;
        }
        
        /// <summary>
        /// Metodo que retnorna o diretorio até o ponto definido. (target)
        /// </summary>
        /// <param name="currentDirectory"></param>
        /// <param name="targetDirectory"></param>
        /// <returns></returns>
        public static string FindTargetDirectory(string currentDirectory, string targetDirectory)
        {
            string currentDirName = new DirectoryInfo(currentDirectory).Name;

            if (string.Equals(currentDirName, targetDirectory, StringComparison.OrdinalIgnoreCase))
            {
                return currentDirectory;
            }

            DirectoryInfo parentDirectory = Directory.GetParent(currentDirectory);

            if (parentDirectory == null)
            {
                return null;
            }

            return FindTargetDirectory(parentDirectory.FullName, targetDirectory);
        }

        /// <summary>
        /// Metodo que trata o JSON para que possa ser manipulado de forma facil.
        /// Aqui passamos o diretorio de forma dinamica.
        /// </summary>
        /// <returns></returns>
        public static List<MappingData> MappingJsonRead()
        {
            string path = FindTargetDirectory(AppDomain.CurrentDomain.BaseDirectory, "GeradorDeCodigo");
            path = path + @"\InterfaceWebConfig\Json\Mapping.json";
            string jsonMap = File.ReadAllText(path);
            List<MappingData> dadosList = JsonConvert.DeserializeObject<List<MappingData>>(jsonMap);

            return dadosList;
        }

        /// <summary>
        /// Metodo que garante a atualização de forma correta do JSON, deve ser sempre utilizado
        /// para garantir que o programa irá funcionar corretamente.
        /// </summary>
        /// <param name="json"></param>
        public static void OverrideJson(List<MappingData> json)
        {
            foreach (var dado in json)
            {
                dado.TipoTraduzido = MappingData.Type[dado.Tipo];
            }
            File.WriteAllText(FindTargetDirectory(AppDomain.CurrentDomain.BaseDirectory, "GeradorDeCodigo") + @"\InterfaceWebConfig\Json\Mapping.json", System.Text.Json.JsonSerializer.Serialize(json));
        }
        #endregion
    }
}
