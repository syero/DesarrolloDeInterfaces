using AltoLapizService.DataObjects;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace AltoLapizService.Hubs
{
    [HubName("PartidaHub")]
    public class PartidaHub:Hub
    {
        /// <summary>
        /// add connection to group
        /// </summary>
        /// <param name="groupName"></param>
        /// <returns></returns>
        public Task JoinGroup(string groupName)
        {
            return Groups.Add(Context.ConnectionId, groupName);
        }   
       


        public void SendGroups(clsGrupo grupoNuevaPartida)
        {
            List<clsGrupo> grupos=new List<clsGrupo>();
            grupos.Add(grupoNuevaPartida);
            Clients.Groups(grupos).crearPartida(grupoNuevaPartida);
        }
    }
}