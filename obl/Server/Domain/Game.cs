﻿using System.Collections;
using System.Collections.ObjectModel;

namespace Server.Domain
{
    public class Game
    {
        public string Title { get; set; }

        public string Cover { get; set; }

        public string Genre { get; set; }

        public string Synopsis { get; set; }

        public string AgeRating { get; set; }

        public int Stars { get; set; }

        public Collection<Qualification> CommunityQualifications { get; set; }

        public Game()
        {
        }

        public Game(string title, string cover, string genre, string synopsis, string ageRating)
        {
            Title = title;
            Cover = cover;
            Genre = genre;
            Synopsis = synopsis;
            AgeRating = ageRating;
            Stars = 0;
            CommunityQualifications = new Collection<Qualification>();
        }

        public override bool Equals(object obj)
        {
            return Title.Equals(((Game) obj).Title);
        }

        public void AddCommunityQualification(Qualification qualification)
        {
            this.CommunityQualifications.Add(qualification);
            UpdateStars();
        }

        public Game GameCopy()
        {
            Game cleanCopyGame = new Game();
            cleanCopyGame.Title = this.Title;
            cleanCopyGame.Cover = this.Cover;
            cleanCopyGame.Genre = this.Genre;
            cleanCopyGame.Synopsis = this.Synopsis;
            cleanCopyGame.AgeRating = this.AgeRating;
            cleanCopyGame.Stars = this.Stars;
            Qualificationcopy(cleanCopyGame);

            return cleanCopyGame;
        }

        private void Qualificationcopy(Game cleanCopyGame)
        {
            cleanCopyGame.CommunityQualifications = new Collection<Qualification>();
            foreach (Qualification quali in CommunityQualifications)
            {
                Qualification copyQualification = new Qualification();
                copyQualification.User = quali.User;
                copyQualification.Stars = quali.Stars;
                copyQualification.Comment = quali.Comment;
                cleanCopyGame.CommunityQualifications.Add(copyQualification);
            }
        }

        private void UpdateStars()
        {
            GameDetails gameDetails = new GameDetails(this);
            Stars = gameDetails.AverageMark;
        }
    }
}