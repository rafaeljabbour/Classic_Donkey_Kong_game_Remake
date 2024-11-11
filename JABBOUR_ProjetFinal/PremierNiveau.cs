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
    public partial class PremierNiveau : Form
    {
        // Ce sont toutes les variables utilisées dans ce Form.

        // Les bools sont utilisés pour déterminer la direction dans laquelle je vais et ce que je fais.
        bool saut, vaGauche, vaDroite;
        bool jouerFrappe = false;
        bool descendre = false;
        bool invincible = false;

        // Crée la gravité
        double force;

        // Ce sont des variables partagées sous différentes formes
        public static int Pointage = 0;
        public static bool Continuer = true;
        public static int vitesseMechant;
        // Variables pour le score, la vie, la vitesse, la gravité...
        int frappe = 0;
        int vitesseJoueur = 8;
        int nbVie = 3;
        int bombe = 0;
        int vitesseHorizontale = 5;
        int graviterMechant = 20;
        int vitesseSaut;
        int frappeTemps;

        // La classe aléatoire génère des boules de feu à des endroits aléatoires de la carte.
        Random rand = new Random();
        // Ces listes contiennent différentes images d'ennemis.
        List<PictureBox> BombeList = new List<PictureBox>();
        List<PictureBox> FeuList = new List<PictureBox>();

        // Ajout d'une musique d'arrière-plan
        SoundPlayer arriere = new SoundPlayer
        (Properties.Resources.Background);
        //Ajout de sons dans l'exécution du programme
        SoundPlayer peutFrappe = new SoundPlayer(Properties.Resources.Got_Hammer);
        SoundPlayer frappeMarteau = new SoundPlayer(Properties.Resources.Hammer_Hit);
        SoundPlayer saute = new SoundPlayer(Properties.Resources.jump);
        SoundPlayer niveauFini = new SoundPlayer(Properties.Resources.Level_Complete);
        SoundPlayer niveauMort = new SoundPlayer(Properties.Resources.Dead);
        SoundPlayer sauteBombe = new SoundPlayer(Properties.Resources.Jump_Barrel);
        SoundPlayer pause = new SoundPlayer(Properties.Resources._09___Pause);

        public PremierNiveau()
        {
            InitializeComponent();
            arriere.Play();
            this.DoubleBuffered = true; // Pour rendre le jeu plus fluide.
            tempBombe.Start(); // commence les bombes
            // Ces instructions déplacent les images du formulaire vers l'arrière.
            pointPetit.SendToBack();
            echelle1.SendToBack();
            echelle2.SendToBack();
            echelle3.SendToBack();
            echelle4.SendToBack();
            echelle5.SendToBack();
            echelle6.SendToBack();
            invisible1.SendToBack();
            invisible2.SendToBack();
            invisible3.SendToBack();
            invisible4.SendToBack();
            invisible5.SendToBack();
        }

        // Méthode pour quand l'utilisateur appuie sur une touche
        private void frmPricipale_KeyDown(object sender, KeyEventArgs e)
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
                        }
                    }
                }
            }  
        }

        // Méthode pour quand l'utilisateur relâche une clé
        private void frmPricipale_KeyUp(object sender, KeyEventArgs e)
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
            }
        }

        // Ce timer est ce qui démarre le jeu et le met en pause.
        private void TimerJeuPrincipale(object sender, EventArgs e)
        {
            // Initialise les scores 
            txtPoint.Text = $"{Pointage}";

            nbBombe.Text = $"{bombe}";

            nbFrappe.Text = $"{frappe}";

            // Définit l'emplacement des boîtes à images transparentes, qui suivent le joueur.
            marioPoint.Location = joueur.Location;

            pointPetit.Location = joueur.Location;

            // Donne de la gravité à tous les ennemis et au joueur dans le jeu.
            joueur.Top += vitesseSaut;

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
                    if ((string)x.Name == "kong" && invincible == false)
                    {
                        if (joueur.Bounds.IntersectsWith(x.Bounds))
                        {
                            nbVie --;
                        }
                    }

                    // instruction pour si une bombe vous touche 
                    if ((string)x.Name == "bombe" && invincible == false)
                    {
                        if (marioPoint.Bounds.IntersectsWith(x.Bounds))
                        {
                            Pointage += 100;
                            pointPetit.Text = "         +100";
                            sauteBombe.Play();
                        }
                        if (joueur.Bounds.IntersectsWith(x.Bounds))
                        {
                            BombeList.Remove((PictureBox)x);
                            this.Controls.Remove(x);
                            nbVie--;
                        }
                    }
                    // instruction pour si une bombe vous touche et que vous utilisez le marteau
                    if ((string)x.Name == "bombe" && invincible)
                    {
                        if (joueur.Bounds.IntersectsWith(x.Bounds))
                        {
                            frappeMarteau.Play();
                            BombeList.Remove((PictureBox)x);
                            this.Controls.Remove(x);
                            Pointage += 300;
                            pointPetit.Text = "         +300";
                            frappe++;
                        }
                    }
                    // Fait disparaître les bombes à la fin.
                    if ((string)x.Name == "bombe")
                    {
                        if (huile.Bounds.IntersectsWith(x.Bounds))
                        {
                            BombeList.Remove((PictureBox)x);
                            this.Controls.Remove(x);
                        }
                    }
                    // Permet à la boule de feu de me tuer et de me donner des points.
                    if ((string)x.Name == "feu" && invincible == false)
                    {
                        if (marioPoint.Bounds.IntersectsWith(x.Bounds))
                        {
                            Pointage += 150;
                            pointPetit.Text = "         +150";
                            sauteBombe.Play();
                        }
                        if (joueur.Bounds.IntersectsWith(x.Bounds))
                        {
                            FeuList.Remove((PictureBox)x);
                            this.Controls.Remove(x);
                            nbVie--;
                        }
                    }
                    // Permet de tuer la boule de feu quand j'ai le marteau.
                    if ((string)x.Name == "feu" && invincible)
                    {
                        frappeMarteau.Play();

                        if (joueur.Bounds.IntersectsWith(x.Bounds))
                        {
                            FeuList.Remove((PictureBox)x);
                            this.Controls.Remove(x);
                            Pointage += 300;
                            pointPetit.Text = "         +300";
                            frappe++;
                        }
                    }
                    // Permet d'avoir un marteau lorsque je ramasse l'objet.
                    if ((string)x.Tag == "frappe")
                    {
                        if (joueur.Bounds.IntersectsWith(x.Bounds))
                        {
                            this.Controls.Remove(x);
                            tempsFrappe.Start();
                            peutFrappe.Play();
                            jouerFrappe = true;
                        }
                    }
                }
            }

            // Déplace les bombes
            foreach (PictureBox j in BombeList)
            {
                j.Left += int.Parse((string)j.Tag);

                if (j.Left < 367 || j.Left + j.Width > 1095)
                {
                    j.Tag = -int.Parse((string)j.Tag);
                }
                j.Tag = j.Tag.ToString();
            }
            // déplace les boules de feu
            foreach (PictureBox m in FeuList)
            {
                m.Left += int.Parse((string)m.Tag);

                if (m.Left < 430 || m.Left + m.Width > 950)
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
            // L'utilisateur bat le niveau s'il touche Princesse
            if (joueur.Bounds.IntersectsWith(princessePeach.Bounds))
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
            if (nbVie == 0 && Continuer)
            {
                this.Controls.Remove(nbVie1);
                tempsJeu.Stop();
                perd.Start();
                niveauMort.Play();
            }
        }

        // Change l'apparence de Maria et lui permet d'utiliser le marteau pendant 10 secondes.
        private void IntervaleFrappe(object sender, EventArgs e)
        {
            frappeTemps = frappeTemps + 1;

            if (frappeTemps <= 10)
            {
                invincible = true;

                if (vaDroite && jouerFrappe)
                {
                    joueur.Image = Properties.Resources.marioFrappeDroite;
                    joueur.SizeMode = PictureBoxSizeMode.Zoom;
                }
                if (vaGauche && jouerFrappe)
                {
                    joueur.Image = Properties.Resources.marioFrappeGauche;
                }
            }
            // Le ramène à la normale
            else
            {
                invincible = false;
                tempsFrappe.Stop();
                jouerFrappe = false;
                peutFrappe.Stop();
                joueur.Image = Properties.Resources.marioCoursDroite;

            }
        }

        // Déclenche les bombes à chaque intervalle et les ajoute au score.
        private void IntervaleBombe(object sender, EventArgs e)
        {
            CreeBombe();
            bombe++;
        }

        // crée des boules de feu 
        private void IntervaleFeu(object sender, EventArgs e)
        {
            CreeFeu();
        }

        // Pour que le joueur ne continue pas à tomber en descendant les escaliers.
        private void tempsDescendre_Tick(object sender, EventArgs e)
        {
            descendre = false;
        }

        // Quand le joueur meurt 
        private void perd_Tick(object sender, EventArgs e)
        {
            PerdNiveau();
            perd.Stop();
        }

        // Lorsque le joueur bat le niveau
        private void gagne_Tick(object sender, EventArgs e)
        {
            GagneNiveau();
            gagne.Stop();
        }

        // Pour que les points s'affichent à côté du joueur chaque fois qu'il en reçoit.
        private void ScorePetit_Tick(object sender, EventArgs e)
        {
            pointPetit.ResetText();
        }

        // Définit les propriétés de la bombe
        private void CreeBombe()
        {
            PictureBox bombe = new PictureBox();

            bombe.Tag = $"{vitesseMechant}";
            bombe.Name = "bombe";

            bombe.Image = Properties.Resources.barille;
            bombe.BackColor = Color.Transparent;
            bombe.SizeMode = PictureBoxSizeMode.Normal;
            bombe.Location = new Point(550, 114);
            BombeList.Add(bombe);
            bombe.SizeMode = PictureBoxSizeMode.AutoSize;
            this.Controls.Add(bombe);
            // Pour que la mouche ne puisse pas frayer sur la grenouille.
            joueur.BringToFront();
        }

        // Définit les propriétés de la boule de feu
        private void CreeFeu()
        {
            PictureBox feu = new PictureBox();

            feu.Tag = $"{vitesseMechant}";
            feu.Name = "feu";

            feu.Image = Properties.Resources.bouleFeu;
            feu.BackColor = Color.Transparent;
            feu.Left = rand.Next(430, 900);
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
            PremierNiveau premierNiveau = new PremierNiveau();
            GagneNiveau1 gagneNiveau1 = new GagneNiveau1(); ;
            premierNiveau.Closed += (s, args) => this.Close();
            gagneNiveau1.Show();
        }
    }
}