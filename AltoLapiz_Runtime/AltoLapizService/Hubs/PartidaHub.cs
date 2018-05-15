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

        /// <summary>
        /// remove connection from group
        /// </summary>
        /// <param name="groupName"></param>
        /// <returns></returns>
        public Task LeaveGroup(string groupName)
        {
            return Groups.Remove(Context.ConnectionId, groupName);
        }

        /// <summary>
        /// send message to the connections in the group.
        /// </summary>
        /// <param name="groupName"></param>
        /// <param name="userName"></param>
        /// <param name="message"></param>
        /// <param name="sendTime"></param>
        public void SendToGroup(clsGrupo group)
        {
            Clients.Group(group.nombrePartida).ReceiveMessage(group.nick, group.mensaje);
        }

        public void SendGroups(clsGrupo group)
        {
            Clients.Groups(group.nombrePartida).ReceiveMessage(group.nick, group.mensaje);
        }
    }
}