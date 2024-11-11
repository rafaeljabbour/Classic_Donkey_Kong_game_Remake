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
    /* 
     * Ce formulaire est le formulaire de départ, il permet à l'utilisateur de voir les instructions,
     * d'apprendre les commandes, de choisir la difficulté et de commencer le jeu.
     */

    public partial class PagePrincipale : Form
    {
        // La musique d'arriere plan
        SoundPlayer debut = new SoundPlayer(Properties.Resources._01Main_Theme);

        public PagePrincipale()
        {
            InitializeComponent();
            debut.Play();
        }

        // Si le bouton est coché, la vitesse devient lente.
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            radioButton1.ForeColor = Color.Red;
            radioButton2.ForeColor = Color.White;
            radioButton3.ForeColor = Color.White;
            PremierNiveau.vitesseMechant = 5;
            DeuxiemeNiveau.vitesseMechant = 5;
            TroisiemeNiveau.vitesseMechant = 5;
            QuatriemeNiveau.vitesseMechant = 5;
        }

        // Si le bouton est coché, la vitesse est fixée à moyenne.
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            radioButton2.ForeColor = Color.Red;
            radioButton1.ForeColor = Color.White;
            radioButton3.ForeColor = Color.White;
            PremierNiveau.vitesseMechant = 9;
            DeuxiemeNiveau.vitesseMechant = 9;
            TroisiemeNiveau.vitesseMechant = 9;
            QuatriemeNiveau.vitesseMechant = 9;
        }

        // Si le bouton est coché, la vitesse est fixée à rapide.
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            radioButton1.Checked = false;
            radioButton3.ForeColor = Color.Red;
            radioButton2.ForeColor = Color.White;
            radioButton1.ForeColor = Color.White;
            PremierNiveau.vitesseMechant = 15;
            DeuxiemeNiveau.vitesseMechant = 15;
            TroisiemeNiveau.vitesseMechant = 15;
            QuatriemeNiveau.vitesseMechant = 15;
        }

        // C'est le bouton pour démarrer le jeu.
        private void ChargerJeu(object sender, EventArgs e)
        {
            // Si aucune difficulté n'est sélectionnée, un avertissement s'affiche à l'écran.
            if (radioButton1.Checked == false && radioButton2.Checked == false && radioButton3.Checked == false)
            {
                MessageBox.Show("Veuillez d'abord sélectionner une difficulté", " Difficulté ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // Sinon, le jeu commence
            else
            {
                this.Hide();
                PagePrincipale pagePrincipale = new PagePrincipale();
                GagneNiveau0 gagneNiveau0 = new GagneNiveau0();
                pagePrincipale.Closed += (s, args) => this.Close();
                gagneNiveau0.Show();
            }
        }

        // Définit la couleur de l'avant-plan du bouton en rouge lorsqu'il est survolé.
        private void ChargerJeu_Hover(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.ForeColor = Color.DarkRed;
        }

        // La couleur des boutons redevient blanche lorsqu'ils ne sont pas survolés.
        private void Demarrer_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.ForeColor = Color.White;
        }

        // Si on le clique, le formulaire de contrôle s'ouvre
        private void Controle_Click(object sender, EventArgs e)
        {
            this.Hide();
            ControleJeu controleJeu = new ControleJeu();
            controleJeu.Closed += (s, args) => this.Close();
            controleJeu.Show();
        }

        // Définit la couleur de l'avant-plan du bouton en rouge lorsqu'il est survolé.
        private void Controle_Hover(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.ForeColor = Color.DarkRed;
        }

        // La couleur des boutons redevient blanche lorsqu'ils ne sont pas survolés.
        private void Controle_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.ForeColor = Color.White;
        }

        // Définit la couleur de l'avant-plan du bouton en rouge lorsqu'il est survolé.
        private void button2_MouseHover(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.ForeColor = Color.DarkRed;
        }

        // La couleur des boutons redevient blanche lorsqu'ils ne sont pas survolés.
        private void button2_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.ForeColor = Color.White;
        }
      
        // Quitte l'application
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Lorsque le bouton est pressé, une boîte de message s'affiche avec les instructions et le but du jeu.
        private void Instructions_Click(object sender, EventArgs e)
        {
            string a = "Mario doit aller de gauche à droite sur les poutres" +
                " et de haut en bas sur les échelles tout en évitant les obstacles " +
                "sur son chemin, soit en sautant par-dessus, soit en les écrasant avec" +
                " le marteau, ou en les évitant. L'objectif sera de guider Mario à travers " +
                "les plateformes afin de remonter un chantier de construction et de sauver la princesse" +
                " Peach de Donkey Kong. Le jeu comporte quatre niveaux distincts, " +
                "dont vous pouvez choisir le niveau de difficulté au départ.";

            string b = "Instructions du Jeu";
            DialogResult rep;
            rep = MessageBox.Show(a, b, MessageBoxButtons.OK,
            MessageBoxIcon.Information);
        }

        // Si le bouton mute est cliqué, la musique est arrêté.
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            debut.Stop();
            audio.Image = Properties.Resources.audioMute;
        }

        // Si l'on double-clique sur le bouton 'mute', la musique est revien.
        private void pictureBox5_DoubleClick(object sender, EventArgs e)
        {
            audio.Image = Properties.Resources.Audio_play;
            debut.Play();
        }

      
    }
}
