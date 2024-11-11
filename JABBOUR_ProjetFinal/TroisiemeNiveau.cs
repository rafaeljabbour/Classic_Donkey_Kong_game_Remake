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
    public partial class TroisiemeNiveau : Form
    {
        // Ce sont toutes les variables utilisées dans ce Form.

        // Les bools sont utilisés pour déterminer la direction dans laquelle je vais et ce que je fais.
        bool saut, vaGauche, vaDroite;
        bool jouerFrappe = false;
        bool descendre = false;

        // Crée la gravité
        double force;

        // Ce sont des variables partagées sous différentes formes
        public static int Pointage;
        public static int vitesseMechant;
        // Variables pour le score, la vie, la vitesse, la gravité...
        int vitesseJoueur = 8;
        int nbVie = 3;
        int bombe = 0;
        int vitesseHorizontale = 5;
        int vitesseVerticale = 3;
        int mechantUnVitesse = 4;
        int graviterMechant = 5;
        int graviterMechant2 = 10;
        int mechantDeuxVitesse = 6;
        int vitesseSaut;

        // Cette liste contien différentes images d'ennemis.
        List<PictureBox> BombeList = new List<PictureBox>();

        public TroisiemeNiveau()
        {
            InitializeComponent();
            arriere.Play();
            pointPetit.SendToBack();
            feu1.SendToBack();
            feu2.SendToBack();
            echelle1.SendToBack();
            echelle2.SendToBack();
            echelle3.SendToBack();
            echelle4.SendToBack();
            echelle6.SendToBack();
            echelle5.SendToBack();
            echelle9.SendToBack();
            echelle8.SendToBack();
            echelle7.SendToBack();
            echelle12.SendToBack();
            echelle11.SendToBack();
            echelle10.SendToBack();
            echelle14.SendToBack();
            echelle13.SendToBack();
            echelle16.SendToBack();
            echelle15.SendToBack();
            poteau1.SendToBack();
            poteau2.SendToBack();
            invisible1.SendToBack();
            invisible2.SendToBack();
            invisible3.SendToBack();
            invisible4.SendToBack();
            invisible5.SendToBack();
            invisible6.SendToBack();
            invisibleD1.SendToBack();
            invisibleD2.SendToBack();
            invisibleD3.SendToBack();
            invisibleD4.SendToBack();
            invisibleD5.SendToBack();
            invisibleD6.SendToBack();
            invisibleD7.SendToBack();
            invisibleD8.SendToBack();
            invisibleD9.SendToBack();
            invisibleD10.SendToBack();
            marioPoint.SendToBack();
        }

        // Ajout d'une musique d'arrière-plan
        SoundPlayer arriere = new SoundPlayer
        (Properties.Resources.Background);
        //Ajout de sons dans l'exécution du programme
        SoundPlayer saute = new SoundPlayer(Properties.Resources.jump);
        SoundPlayer niveauFini = new SoundPlayer(Properties.Resources.Level_Complete);
        SoundPlayer niveauMort = new SoundPlayer(Properties.Resources.Dead);
        SoundPlayer sauteBombe = new SoundPlayer(Properties.Resources.Jump_Barrel);
        SoundPlayer pause = new SoundPlayer(Properties.Resources._09___Pause);
        SoundPlayer accessoire = new SoundPlayer(Properties.Resources._02_Coin);

        // Méthode pour quand l'utilisateur appuie sur une touche
        private void frmTrois_KeyDown(object sender, KeyEventArgs e)
        {
            // Déplacement vers la gauche avec la touche fléchée gauche
            if (e.KeyCode == Keys.Left)
            {
                vaGauche = true;

                if (jouerFrappe == false)
                {
                    joueur.Image = Properties.Resources.marioCoursGauche;
                }
            }
            // Déplacez-vous vers la droite avec la touche fléchée droite
            if (e.KeyCode == Keys.Right)
            {
                vaDroite = true;
                if (jouerFrappe == false)
                {
                    joueur.Image = Properties.Resources.marioCoursDroite;
                }
            }
            // Sauter avec l'espace de la flèche vers le haut
            if (e.KeyCode == Keys.Space && !saut && jouerFrappe == false)
            {
                saut = true;
                saute.Play();
                if (vaDroite && saut)
                {
                    joueur.Image = Properties.Resources.marioSauteDroite;
                }
                else if (vaGauche && saut)
                {
                    joueur.Image = Properties.Resources.marioSauteGauche;
                }
            }
            if (e.KeyCode == Keys.Up && !saut && jouerFrappe == false)
            {
                saute.Play();
                saut = true;

                if (vaDroite && saut)
                {
                    joueur.Image = Properties.Resources.marioSauteDroite;
                }
                else if (vaGauche && saut)
                {
                    joueur.Image = Properties.Resources.marioSauteGauche;
                }
            }
            // Mettez le jeu en pause avec P
            if (e.KeyCode == Keys.P)
            {
                tempsJeu.Stop();
                pause.Play();
            }
            // Reprendre le jeu avec R
            if (e.KeyCode == Keys.R)
            {
                pause.Play();
                tempsJeu.Start();
            }

            // Descendez l'échelle avec la flèche vers le bas.
            foreach (Control i in this.Controls)
            {
                if (i is PictureBox)
                {
                    if ((string)i.Tag == "descendre")
                    {
                        if (e.KeyCode == Keys.Down && joueur.Bounds.IntersectsWith(i.Bounds))
                        {
                            tempsDescendre.Start();
                            descendre = true;

                            invisible1.Tag = "pasPlatforme";
                            invisible2.Tag = "pasPlatforme";
                            invisible3.Tag = "pasPlatforme";
                        }
                    }
                }
            }
        }

        // Méthode pour quand l'utilisateur relâche une clé
        private void frmTrois_KeyUp(object sender, KeyEventArgs e)
        {
            // Arrête de se déplacer dans les directions précédentes

            if (e.KeyCode == Keys.Left)
            {
                vaGauche = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                vaDroite = false;
            }
            if (e.KeyCode == Keys.Space)
            {
                saut = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                descendre = false;
                tempsDescendre.Stop();
                invisible1.Tag = "platforme";
                invisible2.Tag = "platforme";
                invisible3.Tag = "platforme";

            }
        }
       
        // Ce timer est ce qui démarre le jeu et le met en pause.
        private void TimerJeuTrois(object sender, EventArgs e)
        {
            // Initialise les scores 
            txtPoint.Text = PremierNiveau.Pointage.ToString();

            nbBombe.Text = $"{bombe}";

            joueur.Top += vitesseSaut;

            // Définit l'emplacement des boîtes à images transparentes, qui suivent le joueur.
            pointPetit.Location = joueur.Location;

            marioPoint.Location = joueur.Location;

            // Donne de la gravité à tous les ennemis et au joueur dans le jeu.
            feu1.Top += graviterMechant;
            feu2.Top += graviterMechant;
            foreach (PictureBox j in BombeList)
            {
                j.Top += graviterMechant;
            }

            if (vaDroite)
            {
                joueur.Left += vitesseJoueur;
            }
            if (vaGauche)
            {
                joueur.Left -= vitesseJoueur;
            }

            if (saut && force < 0)
            {
                saut = false;
            }

            if (saut)
            {
                vitesseSaut = -8;
                force -= 1;
            }
            else
            {
                vitesseSaut = 10;
            }

            // Cette boucle foreach traite toutes les intersections, points, pertes de vies...
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox)
                {
                    // Tout ce qui touche un paltforme se trouve au-dessus de lui.
                    if ((string)x.Tag == "platforme" || (string)x.Tag == "petitePlateforme")
                    {
                        if (joueur.Bounds.IntersectsWith(x.Bounds) && !saut && descendre == false)
                        {
                            force = 6;
                            joueur.Top = x.Top - joueur.Height;

                            if ((string)x.Name == "plateformehorizontale" && vaGauche == false || (string)x.Name == "plateformehorizontale" && vaDroite == false)
                            {
                                joueur.Left -= vitesseHorizontale;
                            }
                        }

                        if (feu1.Bounds.IntersectsWith(x.Bounds))
                        {
                            feu1.Top = x.Top - feu1.Height;
                        }
                        if (feu2.Bounds.IntersectsWith(x.Bounds))
                        {
                            feu2.Top = x.Top - feu2.Height;
                        }
                    }

                    // instruction pour si kong vous touche 
                    if ((string)x.Name == "kong")
                    {
                        if (joueur.Bounds.IntersectsWith(x.Bounds))
                        {
                            nbVie --;
                        }
                    }

                    // Pour que la bombe rebondissante tombe.
                    if ((string)x.Tag == "platforme")
                    {
                        foreach (PictureBox j in BombeList)
                        {
                            if (j.Bounds.IntersectsWith(x.Bounds))
                            {
                                j.Top =  x.Top - 100;
                            }
                        }
                    }

                    // instruction pour si une boule de feu vous touche 
                    if ((string)x.Tag == "feu")
                    {
                        if (marioPoint.Bounds.IntersectsWith(x.Bounds))
                        {
                            sauteBombe.Play();
                            PremierNiveau.Pointage += 150;
                            pointPetit.Text = "         +150";
                        }
                        if (joueur.Bounds.IntersectsWith(x.Bounds))
                        {
                            this.Controls.Remove(x);
                            nbVie--;
                        }
                    }
                    // instruction pour si une bombe vous touche 
                    if ((string)x.Name == "bombe")
                    {
                        if (joueur.Bounds.IntersectsWith(x.Bounds))
                        {
                            this.Controls.Remove(x);
                            nbVie--;
                        }
                    }
                    // instruction pour si ramasse la accessoires 
                    if ((string)x.Tag == "accessoires" && x.Visible)
                    {
                        if (joueur.Bounds.IntersectsWith(x.Bounds))
                        {
                            accessoire.Play();
                            x.Visible = false;
                            PremierNiveau.Pointage += 300;
                            pointPetit.Text = "         +300";
                        }
                    }
                }
            }

            // Déplace les plateformes
            plateformeVeticale1.Top += vitesseVerticale;

            if (plateformeVeticale1.Top < 335 || plateformeVeticale1.Top > 775)
            {
                vitesseVerticale = -vitesseVerticale;
            }
            plateformeVerticale2.Top += vitesseVerticale;

            if (plateformeVerticale2.Top < 335 || plateformeVerticale2.Top > 775)
            {
                vitesseVerticale = -vitesseVerticale;
            }

            // déplace les boules de feu
            feu1.Left += mechantUnVitesse;
            if (feu1.Left < 495 || feu1.Left > 580)
            {
                mechantUnVitesse = -mechantUnVitesse;
            }
            feu2.Left += mechantDeuxVitesse;
            if (feu2.Left < 980 || feu2.Left > 1120)
            {
                mechantDeuxVitesse = -mechantDeuxVitesse;
            }

            // déplace les bombes a ressort
            foreach (PictureBox j in BombeList)
            {
                j.Left += int.Parse((string)j.Tag);
                
                if (j.Left > 935)
                {
                    j.Tag = 2;
                    j.Top += graviterMechant2;
                }
                if (j.Left + j.Width > 1120)
                {
                    this.Controls.Remove(j);
                }
                j.Tag = j.Tag.ToString();
            }
            // tue l'utilisateur s'il tombe de la carte
            if (joueur.Top + joueur.Height > this.ClientSize.Height + 50)
            {
                nbVie--;
            }
            // L'utilisateur bat le niveau s'il touche Princesse
            if (joueur.Bounds.IntersectsWith(princesseDaisy.Bounds))
            {
                tempsJeu.Stop();

                niveauFini.Play();
                gagne.Start();
            }

            // Fait disparaître les vies de l'écran.
            if (nbVie == 2)
            {
                this.Controls.Remove(nbVie3);
            }
            if (nbVie == 1)
            {
                this.Controls.Remove(nbVie2);
            }
            if (nbVie == 0)
            {
                this.Controls.Remove(nbVie1);
                tempsJeu.Stop();
                niveauMort.Play();
                perd.Start();
                nbVie += 100;
            }
        }

        // Déclenche les bombes à chaque intervalle et les ajoute au score.
        private void IntervaleBombe(object sender, EventArgs e)
        {
            CreeBombe();
            bombe++;
        }

        // Pour que le joueur ne continue pas à tomber en descendant les escaliers.
        private void tempsDescendre_Tick(object sender, EventArgs e)
        {
            descendre = false;
        }

        // Lorsque le joueur bat le niveau
        private void gagne_Tick(object sender, EventArgs e)
        {
            GagneNiveau();
            gagne.Stop();
        }

        // Quand le joueur meurt 
        private void perd_Tick(object sender, EventArgs e)
        {
            PerdNiveau();
            perd.Stop();
        }

        // Pour que les points s'affichent à côté du joueur chaque fois qu'il en reçoit.
        private void scorePetit_Tick(object sender, EventArgs e)
        {
            pointPetit.ResetText();
        }

        // Définit les propriétés de la bombe a ressort
        private void CreeBombe()
        {
            PictureBox bombe = new PictureBox();

            bombe.Tag = $"{vitesseMechant}";
            bombe.Name = "bombe";

            bombe.Image = Properties.Resources.Sauteur;
            bombe.BackColor = Color.Transparent;
            bombe.SizeMode = PictureBoxSizeMode.Normal;
            bombe.Location = new Point(280, 200);
            BombeList.Add(bombe);
            bombe.SizeMode = PictureBoxSizeMode.AutoSize;
            this.Controls.Add(bombe);
            // Pour que la mouche ne puisse pas frayer sur la grenouille.
            joueur.BringToFront();
        }

        // Ouvre le formulaire pour le procahin niveau.
        private void GagneNiveau()
        {
            this.Hide();
            DeuxiemeNiveau deuxiemeNiveau = new DeuxiemeNiveau();
            GagneNiveau3 gagneNiveau3 = new GagneNiveau3();
            deuxiemeNiveau.Closed += (s, args) => this.Close();
            gagneNiveau3.Show();
        }

        // Ouvre le formulaire pour quand vous perdez
        private void PerdNiveau()
        {
            this.Hide();
            FinJeu finJeu = new FinJeu();
            finJeu.Closed += (s, args) => this.Close();
            finJeu.Show();
        }
    }
}
