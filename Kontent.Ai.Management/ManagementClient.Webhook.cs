﻿using Kontent.Ai.Management.Models.Shared;
using Kontent.Ai.Management.Models.Webhooks;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Kontent.Ai.Management;

public partial class ManagementClient
{
    /// <inheritdoc />
    public async Task<IEnumerable<WebhookModel>> ListWebhooksAsync()
    {
        var endpointUrl = _urlBuilder.BuildWebhooksUrl();
        return await _actionInvoker.InvokeReadOnlyMethodAsync<IEnumerable<WebhookModel>>(endpointUrl, HttpMethod.Get);
    }

    /// <inheritdoc />
    public async Task<WebhookModel> GetWebhookAsync(Reference identifier)
    {
        ArgumentNullException.ThrowIfNull(identifier);

        var endpointUrl = _urlBuilder.BuildWebhooksUrl(identifier);
        return await _actionInvoker.InvokeReadOnlyMethodAsync<WebhookModel>(endpointUrl, HttpMethod.Get);
    }

    /// <inheritdoc />
    public async Task<WebhookModel> CreateWebhookAsync(WebhookCreateModel webhook)
    {
        ArgumentNullException.ThrowIfNull(webhook);

        var endpointUrl = _urlBuilder.BuildWebhooksUrl();
        return await _actionInvoker.InvokeMethodAsync<WebhookCreateModel, WebhookModel>(endpointUrl, HttpMethod.Post, webhook);
    }

    /// <inheritdoc />
    public async Task DeleteWebhookAsync(Reference identifier)
    {
        ArgumentNullException.ThrowIfNull(identifier);

        var endpointUrl = _urlBuilder.BuildWebhooksUrl(identifier);
        await _actionInvoker.InvokeMethodAsync(endpointUrl, HttpMethod.Delete);
    }

    /// <inheritdoc />
    public async Task EnableWebhookAsync(Reference identifier)
    {
        ArgumentNullException.ThrowIfNull(identifier);

        var endpointUrl = _urlBuilder.BuildWebhooksEnableUrl(identifier);
        await _actionInvoker.InvokeMethodAsync(endpointUrl, HttpMethod.Put);
    }

    /// <inheritdoc />
    public async Task DisableWebhookAsync(Reference identifier)
    {
        ArgumentNullException.ThrowIfNull(identifier);

        var endpointUrl = _urlBuilder.BuildWebhooksDisableUrl(identifier);
        await _actionInvoker.InvokeMethodAsync(endpointUrl, HttpMethod.Put);
    }
}