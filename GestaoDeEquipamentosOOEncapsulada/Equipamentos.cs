using System;

namespace GestaoDeEquipamentosOOEncapsulada
{
    class Equipamentos
    {
        private string nome;
        private double preco;
        private string numeroDeSerie;
        private DateTime data;
        private string fabricante;
        private int id;

        public Equipamentos(string nome, double preco, string numeroDeSerie, DateTime data, string fabricante, int id)
        {
            this.nome = nome;
            this.preco = preco;
            this.numeroDeSerie = numeroDeSerie;
            this.data = data;
            this.fabricante = fabricante;
            this.id = id;
        }

        public Equipamentos()
        {
        }

        public string Nome
        {
            get { return nome; } 
            set { nome = value; } 
        }

        public double Preco
        {
            get { return preco; }
            set { preco = value; }
        }

        public string NumeroDeSerie
        {
            get { return numeroDeSerie; }
            set { numeroDeSerie = value; }
        }

        public DateTime Data
        {
            get { return data; }
            set { data = value; }
        }

        public string Fabricante
        {
            get { return fabricante; }
            set { fabricante = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

    }
}
