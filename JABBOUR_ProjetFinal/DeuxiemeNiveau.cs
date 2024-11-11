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
    public partial class DeuxiemeNiveau : Form
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
        public static int Pointage;
        public static int vitesseMechant;
        // Variables pour le score, la vie, la vitesse, la gravité...
        int frappe = 0;
        int vitesseJoueur = 8;
        int nbVie = 3;
        int bombe = 0;
        int vitesseHorizontale = 3;
        int mechantUnVitesse = 5;
        int graviterMechant = 20;
        int mechantDeuxVitesse = 2;
        int mechantTroisVitesse = 2;
        int vitesseSaut;
        int frappeTemps;

        // Ces listes contiennent différentes images d'ennemis.
        List<PictureBox> GateauList = new List<PictureBox>();
        List<PictureBox> GateauList2 = new List<PictureBox>();
        List<PictureBox> GateauList3 = new List<PictureBox>();

        // Ajout d'une musique d'arrière-plan
        SoundPlayer arriere = new SoundPlayer
        (Properties.Resources._08___Jumpman_Theme_2);
        //Ajout de sons dans l'exécution du programme
        SoundPlayer peutFrappe = new SoundPlayer(Properties.Resources.Got_Hammer);
        SoundPlayer frappeMarteau = new SoundPlayer(Properties.Resources.Hammer_Hit);
        SoundPlayer saute = new SoundPlayer(Properties.Resources.jump);
        SoundPlayer niveauFini = new SoundPlayer(Properties.Resources.Level_Complete);
        SoundPlayer niveauMort = new SoundPlayer(Properties.Resources.Dead);
        SoundPlayer sauteBombe = new SoundPlayer(Properties.Resources.Jump_Barrel);
        SoundPlayer pause = new SoundPlayer(Properties.Resources._09___Pause);
        SoundPlayer accessoire = new SoundPlayer(Properties.Resources._02_Coin);

        public DeuxiemeNiveau()
        {
            InitializeComponent();
            PremierNiveau.Continuer = false;
            arriere.Play();
            this.DoubleBuffered = true; // Pour rendre le jeu plus fluide.
            // Ces instructions déplacent les images du formulaire vers l'arrière.
            feu1.SendToBack();
            feu2.SendToBack();
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
            echelle15.SendToBack();
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
            marioPoint.SendToBack();
            pointPetit.SendToBack();


            this.DoubleBuffered = true; // Pour rendre le jeu plus fluide.
            tempBombe.Start();
        }

        // Méthode pour quand l'utilisateur appuie sur une touche
        private void frmDeux_KeyDown(object sender, KeyEventArgs e)
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
        private void frmDeux_KeyUp(object sender, KeyEventArgs e)
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
        private void TimerJeuDeux(object sender, EventArgs e)
        {
            // Initialise les scores 
            txtPoint.Text = PremierNiveau.Pointage.ToString();

            nbBombe.Text = $"{bombe}";

            joueur.Top += vitesseSaut;

            // Définit l'emplacement des boîtes à images transparentes, qui suivent le joueur.
            marioPoint.Location = joueur.Location;

            pointPetit.Location = joueur.Location;

            // Donne de la gravité à tous les ennemis et au joueur dans le jeu.
            feu1.Top += graviterMechant;
            feu2.Top += graviterMechant;

            foreach (PictureBox j in GateauList)
            {
                j.Top += graviterMechant;
            }
            foreach (PictureBox x in GateauList2)
            {
                x.Top += graviterMechant;
            }
            foreach (PictureBox n in GateauList3)
            {
                n.Top += graviterMechant;
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

                            if (x.Name == "pDroite" && vaGauche == false || x.Name == "pDroite" && vaDroite == false
                             || x.Name == "pDroite2" && vaGauche == false || x.Name == "pDroite2" && vaDroite == false)
                            {
                                joueur.Left -= vitesseHorizontale;
                            }
                            if (x.Name == "pGauche" && vaGauche == false || x.Name == "pGauche" && vaDroite == false)
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

                        foreach (PictureBox j in GateauList)
                        {
                            if (j.Bounds.IntersectsWith(x.Bounds))
                            {
                                j.Top = x.Top - j.Height;
                            }
                        }
                        foreach (PictureBox m in GateauList2)
                        {
                            if (m.Bounds.IntersectsWith(x.Bounds))
                            {
                                m.Top = x.Top - m.Height;
                            }
                        }
                        foreach (PictureBox n in GateauList3)
                        {
                            if (n.Bounds.IntersectsWith(x.Bounds))
                            {
                                n.Top = x.Top - n.Height;
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
                    // instruction pour si un gateau vous touche 
                    if ((string)x.Name == "gateau" && invincible == false)
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
                    // instruction pour si un gateau vous touche et que vous utilisez le marteau
                    if ((string)x.Name == "gateau" && invincible)
                    {
                        if (marioPoint.Bounds.IntersectsWith(x.Bounds))
                        {
                            frappeMarteau.Play();
                            PremierNiveau.Pointage += 300;
                            pointPetit.Text = "         +300";
                        }
                        if (joueur.Bounds.IntersectsWith(x.Bounds))
                        {
                            this.Controls.Remove(x);
                            frappe++;
                        }
                    }
                    // Permet à la boule de feu de me tuer et de me donner des points.
                    if ((string)x.Tag == "feu" && invincible == false)
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
                    // Permet de tuer la boule de feu quand j'ai le marteau.
                    if ((string)x.Tag == "feu" && invincible)
                    {
                        if (marioPoint.Bounds.IntersectsWith(x.Bounds))
                        {
                            frappeMarteau.Play();
                            PremierNiveau.Pointage += 300;
                            pointPetit.Text = "         +300";
                        }
                        if (joueur.Bounds.IntersectsWith(x.Bounds))
                        {
                            this.Controls.Remove(x);
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
                            jouerFrappe = true;
                            peutFrappe.Play();
                        }
                    }
                    // Permet de ramasser les accessoires
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

                    // Efface les images de la liste pour que le jeu ne commence pas à traîner. 
                    if ((string)x.Name == "gateau")
                    {
                        if (mur1.Bounds.IntersectsWith(x.Bounds))
                        {
                            GateauList.Remove((PictureBox)x);
                            this.Controls.Remove(x);
                        }
                        if (mur2.Bounds.IntersectsWith(x.Bounds))
                        {
                            GateauList2.Remove((PictureBox)x);
                            this.Controls.Remove(x);
                        }
                        if (mur1.Bounds.IntersectsWith(x.Bounds))
                        {
                            GateauList3.Remove((PictureBox)x);
                            this.Controls.Remove(x);
                        }
                    }
                }
            }

            // Déplace kong
            kong.Left += mechantUnVitesse;

            if (kong.Left < 450 || kong.Left + kong.Width > 1050)
            {
                mechantUnVitesse = -mechantUnVitesse;
            }

            // Déplace les boules de feux
            feu1.Left += mechantDeuxVitesse;
            if (feu1.Left < 620 || feu1.Left + feu1.Width > 870)
            {
                mechantDeuxVitesse = -mechantDeuxVitesse;
            }
            feu2.Left += mechantTroisVitesse;
            if (feu2.Left < 620 || feu2.Left + feu2.Width > 870)
            {
                mechantTroisVitesse = -mechantTroisVitesse;
            }

            // Déplace les boules les gateaux
            foreach (PictureBox j in GateauList)
            {
                j.Left += int.Parse((string)j.Tag);

                if (j.Left + j.Width > 1120)
                {
                    this.Controls.Remove(j);
                }
                j.Tag = j.Tag.ToString();
            }
            foreach (PictureBox x in GateauList2)
            {
                x.Left += int.Parse((string)x.Tag);

                if (x.Left + x.Width > 735)
                {
                    this.Controls.Remove(x);
                }
                x.Tag = x.Tag.ToString();
            }
            foreach (PictureBox n in GateauList3)
            {
                n.Left -= int.Parse((string)n.Tag);

                if (n.Left + n.Width < 795)
                {
                    this.Controls.Remove(n);
                }
                n.Tag = n.Tag.ToString();
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
                niveauMort.Play();
                perd.Start();
                nbVie += 100;
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

        // Déclenche les gateaux à chaque intervalle et les ajoute au score.
        private void IntervaleBombe(object sender, EventArgs e)
        {
            CreeGateau1();
            CreeGateau2();
            CreeGateau3();
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

        private void scorePetit_Tick(object sender, EventArgs e)
        {
            pointPetit.ResetText();
        }
        
        // Définit les propriétés des gateaux
        private void CreeGateau1()
        {
            PictureBox gateau = new PictureBox();

            gateau.Tag = $"{vitesseMechant}";
            gateau.Name = "gateau";

            gateau.Image = Properties.Resources.gateau;
            gateau.BackColor = Color.Transparent;
            gateau.SizeMode = PictureBoxSizeMode.Normal;
            gateau.Location = new Point(400, 670);
            GateauList.Add(gateau);
            gateau.SizeMode = PictureBoxSizeMode.AutoSize;
            this.Controls.Add(gateau);
            // Pour que la mouche ne puisse pas frayer sur la grenouille.
            joueur.BringToFront();
        }
        private void CreeGateau2()
        {
            PictureBox gateau = new PictureBox();

            gateau.Tag = $"{vitesseMechant}";
            gateau.Name = "gateau";

            gateau.Image = Properties.Resources.gateau;
            gateau.BackColor = Color.Transparent;
            gateau.SizeMode = PictureBoxSizeMode.Normal;
            gateau.Location = new Point(400, 410);
            GateauList2.Add(gateau);
            gateau.SizeMode = PictureBoxSizeMode.AutoSize;
            this.Controls.Add(gateau);
            // Pour que la mouche ne puisse pas frayer sur la grenouille.
            joueur.BringToFront();
        }
        private void CreeGateau3()
        {
            PictureBox gateau = new PictureBox();

            gateau.Tag = $"{vitesseMechant}";
            gateau.Name = "gateau";

            gateau.Image = Properties.Resources.gateau;
            gateau.BackColor = Color.Transparent;
            gateau.SizeMode = PictureBoxSizeMode.Normal;
            gateau.Location = new Point(1090, 410);
            GateauList3.Add(gateau);
            gateau.SizeMode = PictureBoxSizeMode.AutoSize;
            this.Controls.Add(gateau);
            // Pour que la mouche ne puisse pas frayer sur la grenouille.
            joueur.BringToFront();
        }

        // Ouvre le formulaire pour le procahin niveau.
        private void GagneNiveau()
        {
            this.Hide();
            DeuxiemeNiveau deuxiemeNiveau = new DeuxiemeNiveau();
            GagneNiveau2 gagneNiveau2 = new GagneNiveau2();
            deuxiemeNiveau.Closed += (s, args) => this.Close();
            gagneNiveau2.Show();
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