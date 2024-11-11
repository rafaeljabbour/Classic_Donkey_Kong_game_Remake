﻿/*
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
    public partial class QuatriemeNiveau : Form
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
        int graviterMechant = 20;
        int plateformeTue = 8;
        int vitesseSaut;

        // La classe aléatoire génère des boules de feu à des endroits aléatoires de la carte.
        Random rand = new Random();
        // Ces listes contiennent différentes images d'ennemis.
        List<PictureBox> BombeList = new List<PictureBox>();
        List<PictureBox> FeuList = new List<PictureBox>();

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

        public QuatriemeNiveau()
        {
            InitializeComponent();
            arriere.Play();
            this.DoubleBuffered = true; // Pour rendre le jeu plus fluide.
            // Ces instructions déplacent les images du formulaire vers l'arrière.
            pointPetit.SendToBack();
            echelle1.SendToBack();
            echelle2.SendToBack();
            echelle3.SendToBack();
            echelle4.SendToBack();
            echelle5.SendToBack();
            echelle6.SendToBack();
            echelle7.SendToBack();
            echelle8.SendToBack();
            echelle9.SendToBack();
            echelle10.SendToBack();
            echelle11.SendToBack();
            echelle12.SendToBack();
            echelle13.SendToBack();
            echelle14.SendToBack();
            poteau1.SendToBack();
            poteau2.SendToBack();
            invisible1.SendToBack();
            invisible2.SendToBack();
            invisible3.SendToBack();
            invisible4.SendToBack();
            invisible5.SendToBack();
            invisible6.SendToBack();
            invisible7.SendToBack();
            invisible8.SendToBack();
            invisible9.SendToBack();
            invisible10.SendToBack();
            invisible11.SendToBack();
            invisible12.SendToBack();
            invisible13.SendToBack();
            invisible14.SendToBack();
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
            invisibleD11.SendToBack();
            invisibleD12.SendToBack();
            invisibleD13.SendToBack();
            invisibleD14.SendToBack();
            mine1.SendToBack();
            mine2.SendToBack();
            mine3.SendToBack();
            mine4.SendToBack();
            mine5.SendToBack();
            mine6.SendToBack();
            mine7.SendToBack();
            mine8.SendToBack();
            marioPoint.SendToBack();
        }

        // Méthode pour quand l'utilisateur appuie sur une touche
        private void frmQuatre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                vaGauche = true;
                joueur.Image = Properties.Resources.marioCoursGauche;
            }
            if (e.KeyCode == Keys.Right)
            {
                vaDroite = true;
                joueur.Image = Properties.Resources.marioCoursDroite;
            }
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
            if (e.KeyCode == Keys.P)
            {
                pause.Play();
                tempsJeu.Stop();
            }
            if (e.KeyCode == Keys.R)
            {
                pause.Play();
                tempsJeu.Start();
            }
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
                        }
                    }
                }
            }
        }

        // Méthode pour quand l'utilisateur relâche une clé
        private void frmQuatre_KeyUp(object sender, KeyEventArgs e)
        {
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
            }
        }

        // Ce timer est ce qui démarre le jeu et le met en pause.
        private void TimerJeuQuatre(object sender, EventArgs e)
        {
            // Initialise les scores 
            txtPoint.Text = PremierNiveau.Pointage.ToString();

            nbBombe.Text = $"{bombe}";

            joueur.Top += vitesseSaut;

            // Définit l'emplacement des boîtes à images transparentes, qui suivent le joueur.
            pointPetit.Location = joueur.Location;

            marioPoint.Location = joueur.Location;

            // Donne de la gravité à tous les ennemis et au joueur dans le jeu.
            foreach (PictureBox j in BombeList)
            {
                j.Top += graviterMechant;

            }
            foreach (PictureBox m in FeuList)
            {
                m.Top += graviterMechant;
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

                        foreach (PictureBox j in BombeList)
                        {
                            if (j.Bounds.IntersectsWith(x.Bounds))
                            {
                                j.Top = x.Top - j.Height;
                            }
                        }
                        foreach (PictureBox m in FeuList)
                        {
                            if (m.Bounds.IntersectsWith(x.Bounds))
                            {
                                m.Top = x.Top - m.Height;
                            }
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

                    // Permet à la boule de feu de me tuer et de me donner des points.
                    if ((string)x.Name == "feu")
                    {
                        if (marioPoint.Bounds.IntersectsWith(x.Bounds))
                        {
                            sauteBombe.Play();
                            Pointage += 150;
                            pointPetit.Text = "         +150";
                        }
                        if (joueur.Bounds.IntersectsWith(x.Bounds))
                        {
                            FeuList.Remove((PictureBox)x);
                            this.Controls.Remove(x);
                            nbVie--;
                            bombe--;
                        }
                    }
                    // Permet de briser les mines sur le sol, pour faire tomber Donkey Kong.
                    if ((string)x.Tag == "mine" && x.Visible)
                    {
                        if (joueur.Bounds.IntersectsWith(x.Bounds))
                        {
                            accessoire.Play();
                            x.Visible = false;
                            PremierNiveau.Pointage += 100;
                            pointPetit.Text = "         +100";
                            plateformeTue--;
                        }
                    }
                    // Permet de ramasser les accessoires.
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

            // déplace les boules de feu
            foreach (PictureBox m in FeuList)
            {
                m.Left += int.Parse((string)m.Tag);

                if (m.Left < 350 || m.Left > 1000)
                {
                    m.Tag = -int.Parse((string)m.Tag);
                }
                m.Tag = m.Tag.ToString();
            }

            // tue l'utilisateur s'il tombe de la carte
            if (joueur.Top + joueur.Height > this.ClientSize.Height + 50)
            {
                nbVie--;
            }
            // Si l'utilisateur bat Kong et le fait tomber
            if (plateformeTue == 0)
            {
                tempsJeu.Stop();

                gagne.Start();
                niveauFini.Play();
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
                perd.Start();
                niveauMort.Play();
                nbVie += 100;
            }
            // Ne permet pas trop de boules de feu sur la carte.
            if (bombe < 5)
            {
                tempFeu.Start();
            }
            else if (bombe >=5)
            {
                tempFeu.Stop();
            }
        }

        // crée des boules de feu 
        private void IntervaleFeu(object sender, EventArgs e)
        {
            CreeFeu();
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

        // Définit les propriétés de la boule de feu
        private void CreeFeu()
        {
            PictureBox feu = new PictureBox();

            feu.Tag = $"{vitesseMechant}";
            feu.Name = "feu";

            feu.Image = Properties.Resources.bouleFeu;
            feu.BackColor = Color.Transparent;
            feu.Left = rand.Next(425, 840);
            feu.Top = rand.Next(75, 900);
            FeuList.Add(feu);
            feu.Size = new Size(35, 35);
            feu.SizeMode = PictureBoxSizeMode.Zoom;
            this.Controls.Add(feu);
            // Pour que la mouche ne puisse pas frayer sur la grenouille.
            joueur.BringToFront();
        }

        // Ouvre le formulaire pour quand vous perdez
        private void PerdNiveau()
        {
            this.Hide();
            FinJeu finJeu = new FinJeu();
            finJeu.Closed += (s, args) => this.Close();
            finJeu.Show();
        }

        // Ouvre le formulaire pour le procahin niveau.
        private void GagneNiveau()
        {
            this.Hide();
            GagneJeu gagneJeu = new GagneJeu();
            gagneJeu.Closed += (s, args) => this.Close();
            gagneJeu.Show();
        }
    }
}