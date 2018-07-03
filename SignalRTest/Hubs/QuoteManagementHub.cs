using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using SignalRTest.Models;
using SignalRTestEntity.Entity;

namespace SignalRTest.Hubs
{
    public class QuoteManagementHub : Hub
    {
        private readonly List<string> _connections = new List<string>();

        public void JoinGroup(List<string> groups)
        {
            if (groups.Count > 0)
            {
                foreach (var group in groups)
                {
                    Groups.Add(Context.ConnectionId, group);
                }
                _connections.Add(Context.ConnectionId);
            }
        }

        public void LeaveGroup(string group)
        {
            if (!String.IsNullOrEmpty(group))
            {
                Groups.Remove(Context.ConnectionId, group);
            }
        }

        public void AddQuote(QuoteEntity quoteEntity)
        {
            Clients.Group("add").AddQuote(quoteEntity);
        }

        public void UpdateQuote(QuoteEntity quoteEntity)
        {
            Clients.Group("update").UpdateQuote(quoteEntity);
        }

        public void DeleteQuote(int quoteId)
        {
            Clients.Group("delete").RemoveQuote(quoteId);
        }
    }

    public class TestHub : Hub
    {
        private readonly List<string> _connections = new List<string>();

        public void JoinGroup(List<string> groups)
        {
            if (groups.Count > 0)
            {
                foreach (var group in groups)
                {
                    Groups.Add(Context.ConnectionId, group);
                }
                _connections.Add(Context.ConnectionId);
            }
        }

        public void LeaveGroup(string group)
        {
            if (!String.IsNullOrEmpty(group))
            {
                Groups.Remove(Context.ConnectionId, group);
            }
        }

        public void AddQuote(QuoteEntity quoteEntity)
        {
            Clients.Group("add").AddQuote(quoteEntity);
        }

        public void UpdateQuote(QuoteEntity quoteEntity)
        {
            Clients.Group("update").UpdateQuote(quoteEntity);
        }

        public void DeleteQuote(int quoteId)
        {
            Clients.Group("delete").RemoveQuote(quoteId);
        }
    }
}