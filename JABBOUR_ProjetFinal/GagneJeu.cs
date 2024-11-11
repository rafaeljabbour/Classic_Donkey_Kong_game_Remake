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
    // Ce formulaire apparaît lorsque l'utilisateur bat Donkey Kong et récupère sa princesse.
    public partial class GagneJeu : Form
    {
        // La musique d'arriere plan
        SoundPlayer meur = new SoundPlayer(Properties.Resources._12_Donkey_Kong_Falling__1_);

        // Temps de chute de Donkey Kong
        int dkTombeTemps;

        public GagneJeu()
        {
            InitializeComponent();
            meur.Play();
            triste.SendToBack();
            joueur.SendToBack();
        }
        // Mario danse de joie et Donkey Kong lui tombe sur la tête.
        private void dance_Tick(object sender, EventArgs e)
        {
            dkTombeTemps = dkTombeTemps + 1;
            if (dkTombeTemps >= 3)
            {
                mort.Visible = true;
                triste.Visible = false;
            }
        }
        // pour animer la mort de Donkey Kong
        private void tempsJeu_Tick(object sender, EventArgs e)
        {
            if (mort.Top < 539 && mort.Visible == true)
            {
                mort.Top += 5;
            }
        }

        // Ferme la fenêtre après la fin du chronomètre et affiche le score final.
        private void Score_Tick(object sender, EventArgs e)
        {
            this.Hide();
            FinGagne fingagne = new FinGagne();
            fingagne.Closed += (s, args) => this.Close();
            fingagne.Show();
            Score.Stop();
        }
    }
}
