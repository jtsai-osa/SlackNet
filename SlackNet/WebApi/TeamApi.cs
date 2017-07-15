﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Args = System.Collections.Generic.Dictionary<string, object>;

namespace SlackNet.WebApi
{
    public class TeamApi
    {
        private readonly SlackApiClient _client;
        public TeamApi(SlackApiClient client) => _client = client;

        /// <summary>
        /// Used to get the access logs for users on a team.
        /// </summary>
        /// <param name="before">End of time range of logs to include in results (inclusive).</param>
        /// <param name="count">Number of items to return per page.</param>
        /// <param name="page">Page number of results to return.</param>
        /// <param name="cancellationToken"></param>
        public Task<AccessLogsResponse> AccessLogs(DateTime before, int count = 100, int page = 1, CancellationToken? cancellationToken = null) =>
            _client.Get<AccessLogsResponse>("team.accessLogs", new Args
                {
                    { "before", before.ToTimestamp() },
                    { "count", count },
                    { "page", page }
                }, cancellationToken);

        /// <summary>
        /// Used to get the access logs for users on a team.
        /// </summary>
        /// <param name="before">End of time range of logs to include in results (inclusive).</param>
        /// <param name="count">Number of items to return per page.</param>
        /// <param name="page">Page number of results to return.</param>
        /// <param name="cancellationToken"></param>
        public Task<AccessLogsResponse> AccessLogs(int? before = null, int count = 100, int page = 1, CancellationToken? cancellationToken = null) =>
            _client.Get<AccessLogsResponse>("team.accessLogs", new Args
                {
                    { "before", before },
                    { "count", count },
                    { "page", page }
                }, cancellationToken);

        /// <summary>
        /// Lists billable information for each user on the team.
        /// Currently this consists solely of whether the user is subject to billing per Slack's Fair Billing policy.
        /// </summary>
        /// <param name="userId">A user to retrieve the billable information for. Defaults to all users.</param>
        /// <param name="cancellationToken"></param>
        public async Task<IList<BillableInfo>> BillableInfo(string userId = null, CancellationToken? cancellationToken = null) =>
            (await _client.Get<BillableInfoResponse>("team.billableInfo", new Args { { "user", userId } }, cancellationToken).ConfigureAwait(false)).BillableInfo;

        /// <summary>
        /// Provides information about your team.
        /// </summary>
        /// <param name="cancellationToken"></param>
        public async Task<Team> Info(CancellationToken? cancellationToken = null) =>
            (await _client.Get<TeamResponse>("team.info", new Args(), cancellationToken).ConfigureAwait(false)).Team;

        /// <summary>
        /// Lists the integration activity logs for a team, including when integrations are added, modified and removed.
        /// This method can only be called by Admins.
        /// </summary>
        /// <param name="appId">Filter logs to this Slack app. Defaults to all logs.</param>
        /// <param name="changeType">Filter logs with this change type. Defaults to all logs.</param>
        /// <param name="count">Number of items to return per page.</param>
        /// <param name="page">Page number of results to return.</param>
        /// <param name="serviceId">Filter logs to this service. Defaults to all logs.</param>
        /// <param name="userId">Filter logs generated by this user’s actions. Defaults to all logs.</param>
        /// <param name="cancellationToken"></param>
        public Task<IntegrationLogsResponse> IntegrationLogs(
            string appId = null,
            ChangeType? changeType = null,
            int count = 100,
            int page = 1,
            string serviceId = null,
            string userId = null,
            CancellationToken? cancellationToken = null
        ) =>
            _client.Get<IntegrationLogsResponse>("team.integrationLogs", new Args
                    {
                        { "app_id", appId },
                        { "change_type", changeType },
                        { "count", count },
                        { "page", page },
                        { "service_id", serviceId },
                        { "user", userId }
                    },
                cancellationToken);
    }
}