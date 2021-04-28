using System;

namespace GestaoDeEquipamentosOOEncapsulada
{
    class Chamados
    {
        private string titulo;
        private string descricao;
        private string equipamento;
        private DateTime dataAbertura;
        private int id;

        public Chamados(string titulo, string descricao, DateTime dataAbertura, int id)
        {
            this.titulo = titulo;
            this.descricao = descricao;
            this.dataAbertura = dataAbertura;
            this.id = id;
        }

        public Chamados()
        {
        }

        public string Titulo
        {
            get { return titulo; }
            set { titulo = value; }
        }

        public string Descricao
        {
            get { return descricao; }
            set { descricao = value; }
        }

        public DateTime DataAbertura
        {
            get { return dataAbertura; }
            set { dataAbertura = value; }
        }

        public int Id
        {
            get { return id; }
        }

        public string Equipamento 
        {
            get { return equipamento; }
            set { equipamento = value; }
        }
    }
}
