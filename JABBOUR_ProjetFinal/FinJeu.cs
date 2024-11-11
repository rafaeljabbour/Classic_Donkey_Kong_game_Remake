/*
Rafael Jabbour
Ecole secondaire catholique Renaissance
ICS3U, Sem 2, 2021-22
Dernière modification : 19-05-6-2022

DESCRIPTION:
Ce programme permet à l'utilisateur de jouer au jeu "Donkey Kong", dans ce jeu Mario
doit aller de gauche à droite sur les poutres et de haut en bas sur les échelles
tout en évitant les obstacles sur son chemin, soit en sautant par-dessus, soit en
les écrasant avec le marteau, ou en les évitant. L'objectif sera de guider Mario
à travers les plateformes afin de remonter un chantier de construction et de 
sauver la princesse Peach de Donkey Kong. Le jeu comporte quatre niveaux distincts,
dont vous pouvez choisir le niveau de difficulté au départ. Le jeu comprend également 
des effets sonores et de la musique pour le rendre plus agréable.

HYPOTHESES:
L'utilisateur utilise les touches flèche (↑ ↓ → ←) qui permet à Mario de se déplacer
à gauche, à droite et de monter et descendre des échelles.
La barre d’espace permet à Mario de sauter par-dessus les obstacles et peut également être utilisé pour monter les échelles.
Alors, allons secourir la princesse avant qu'il ne soit trop tard ! Vite !!
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace JABBOUR_ProjetFinal
{
    // Ce formulaire apparaît après la mort de l'utilisateur
    public partial class FinJeu : Form
    {
        // La musique d'arriere plan
        SoundPlayer recommence = new SoundPlayer(Properties.Resources._01Main_Theme);

        public FinJeu()
        {
            InitializeComponent();
            recommence.Play();
            // Indique le score additionné de tous les niveaux.
            txtPoint.Text = PremierNiveau.Pointage.ToString();
        }

        // Redémarre le jeu depuis le niveau 1
        private void Reessayer_Click(object sender, EventArgs e)
        {
            this.Hide();
            PremierNiveau premierNiveau = new PremierNiveau();
            premierNiveau.Closed += (s, args) => this.Close();
            premierNiveau.Show();
            PremierNiveau.Pointage = 0;
        }

        // Renvoie l'utilisateur au menu principal.
        private void Menu_Click(object sender, EventArgs e)
        {
            this.Hide();
            PagePrincipale pagePrincipale = new PagePrincipale();
            pagePrincipale.Closed += (s, args) => this.Close();
            pagePrincipale.Show();
            PremierNiveau.Pointage = 0;
        }

        // Ouvre le formulaire de contrôle lorsque le bouton est cliqué.
        private void Controle_Click(object sender, EventArgs e)
        {
            this.Hide();
            ControleJeu controleJeu = new ControleJeu();
            controleJeu.Closed += (s, args) => this.Close();
            controleJeu.Show();
        }
    }
}
