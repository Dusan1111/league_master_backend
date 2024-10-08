using ApplicationCore.Interfaces.RepositoryInterfaces;
using Domain.Entites;
using Domain.Entities;
using League_Master.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly LeagueMasterDbContext _dbContext;

        public PlayerRepository(LeagueMasterDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddNewPlayer(Player newPlayer, int teamId, int leagueId)
        {
            if (await IsPlayerRegisteredInTheLeagueForOtherTeam(leagueId, teamId, newPlayer.Name, newPlayer.Lastname))
            {
                return -1;
            }
            if (!await DoesLeagueExist(leagueId))
            {
                return -2;
            }
            if (!await DoesTeamExist(teamId))
            {
                return -3;
            }
            
            using (var dbContextTransaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    var addedPlayer = await _dbContext.Players.AddAsync(newPlayer);
                    var addedPlayerResult = await _dbContext.SaveChangesAsync();

                    if (addedPlayerResult > 0)
                    {
                        var newPlayerTeamRelation = new PlayerTeam()
                        {
                            PlayerId = addedPlayer.Entity.Id,
                            TeamId = teamId,
                            LeagueId = leagueId,
                        };
                        var addedPlayerTeamRelation = await _dbContext.PlayerTeams.AddAsync(newPlayerTeamRelation);
                    }

                    await _dbContext.SaveChangesAsync();
                    await dbContextTransaction.CommitAsync();

                    return addedPlayer.Entity.Id;
                }

                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                    throw;
                }
            }
        }

        public async Task<int> DeletePlayer(int playerId)
        {
            var playerForDelete = await _dbContext.Players.FindAsync(playerId);
                                                    
            var playerTeamForDelete = await _dbContext.PlayerTeams
                .Where(x => x.PlayerId== playerId)
                .FirstOrDefaultAsync();

            if (playerTeamForDelete is not null)
            {
                _dbContext.PlayerTeams.Remove(playerTeamForDelete);
            }
            if (playerForDelete is not null)
            {
                _dbContext.Players.Remove(playerForDelete);

                return await _dbContext.SaveChangesAsync();
            }

            return 0;
        }

        public async Task<Player> GetPlayerDetails(int playerId)
        {
            return await _dbContext.Players.FindAsync(playerId);
        }

        public async Task<int> UpdatePlayer(int playerId, Player playerToUpdate)
        {
            var updatedPlayer = await _dbContext.Players.FirstOrDefaultAsync(player => player.Id == playerId);

            if (updatedPlayer is not null)
            {
                updatedPlayer.Name = playerToUpdate.Name;
                updatedPlayer.JerseyNumber = playerToUpdate.JerseyNumber;
                updatedPlayer.SuspendedFromRound = playerToUpdate.SuspendedFromRound;
                updatedPlayer.SuspendedUntilRound = playerToUpdate.SuspendedUntilRound;

                return await _dbContext.SaveChangesAsync();
            }

            return -1;
        }

        private async Task<bool> DoesTeamExist(int teamId)
        {
            return await _dbContext.Teams
                .AnyAsync(team => team.Id == teamId);
        }

        private async Task<bool> DoesLeagueExist(int leagueId)
        {
            return await _dbContext.Leagues
                .AnyAsync(league => league.Id == leagueId);
        }

        private async Task<bool> IsPlayerRegisteredInTheLeagueForOtherTeam(int leagueId, int teamId, string firstName, string lastName)
        {
            return await _dbContext.PlayerTeams
                .AnyAsync(playerTeam => playerTeam.LeagueId == leagueId
                     && playerTeam.TeamId == teamId 
                     && playerTeam.Player.Name.Equals(firstName)
                     && playerTeam.Player.Lastname.Equals(lastName)
                  // Include ne radi proveriti zašto
                  //&& playerTeam.Name.Equals(umnc)
                  // && playerTeam.UMNC.Equals(umnc)

                  );
        }
    }
}
