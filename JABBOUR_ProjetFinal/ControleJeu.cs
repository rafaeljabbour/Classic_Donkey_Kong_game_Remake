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
    // Ce formulaire explique à l'utilisateur les commandes du jeu et lui donne quelques conseils.
    public partial class ControleJeu : Form
    {
        // Music d'arriere plan
        SoundPlayer controle = new SoundPlayer(Properties.Resources._01_controls);

        // Temps pour les instructions 
        int temps;
        public ControleJeu()
        {
            InitializeComponent();
            controle.Play();
            timerInstruction.Start();
            instruction2.SendToBack();
            Instruction1.SendToBack();
        }

        // Timer pour les messages d'animation
        private void IntervaleInstructions1(object sender, EventArgs e)
        {
            temps = temps + 1;

            // Chaque instruction if affiche un message différent expliquant les animations.
            if (temps > 3 && temps <= 8)
            {
                lblInstruction.Text = "Appuyez sur le haut et le bas pour monter ou descendre d'une échelle.";
            }
            else if (temps > 8 && temps <= 12)
            {
                lblInstruction.Text = "Appuyez sur l'espace pour sauter";
            }
            else if (temps > 12 && temps <= 15)
            {
                lblInstruction.Text = "Appuyez sur P pour mettre le jeu en pause et appuyez sur R pour reprendre le jeu";
            }
            else if (temps > 15)
            {
               lblInstruction.Visible = false;
               Instruction1.Visible = false;
               instruction2.Visible = true;
               lblInstructions2.Visible = true;
               lblCache.Visible = true;
            }
        }

        // Donner une couleur rouge au bouton lors de l'etat 'hover'
        private void RevenirJeu_Hover(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.ForeColor = Color.DarkRed;
        }

        // Lorsque l'état de survol est arreter, la couleur du bouton redevien blanche.
        private void RevenirJeu_Leave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.ForeColor = Color.White;
        }

        // Lorsque l'utilisateur clique dessus, il est renvoyé au menu principal.
        private void btnRetourne_Click(object sender, EventArgs e)
        {
            this.Hide();
            PagePrincipale pagePrincipale = new PagePrincipale();
            pagePrincipale.Closed += (s, args) => this.Close();
            pagePrincipale.Show();
        }
    }
}
