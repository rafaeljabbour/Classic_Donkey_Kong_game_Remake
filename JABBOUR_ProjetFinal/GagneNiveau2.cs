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
    // Ce formulaire est utilisé pour montrer à l'utilisateur la ligne de progression qu'il doit accomplir.
    public partial class GagneNiveau2 : Form
    {
        // Musique d'arrire plan
        SoundPlayer prochain = new SoundPlayer(Properties.Resources._03___How_High_Can_You_Get);

        // Pour montrer le poitage a present
        public static int Pointage;

        public GagneNiveau2()
        {
            InitializeComponent();
            // Affiche le pointage a present 
            txtPoint.Text = PremierNiveau.Pointage.ToString();
            prochain.Play();
        }

        // Commence le troisieme niveau
        private void prochainNiveau_Tick(object sender, EventArgs e)
        {
            this.Hide();
            TroisiemeNiveau troisiemeNiveau = new TroisiemeNiveau();
            troisiemeNiveau.Closed += (s, args) => this.Close();
            troisiemeNiveau.Show();
            prochainNiveau.Stop();
        }
    }
}
