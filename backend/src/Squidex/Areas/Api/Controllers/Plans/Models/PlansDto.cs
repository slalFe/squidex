﻿// ==========================================================================
//  Squidex Headless CMS
// ==========================================================================
//  Copyright (c) Squidex UG (haftungsbeschraenkt)
//  All rights reserved. Licensed under the MIT license.
// ==========================================================================

using Squidex.Domain.Apps.Entities.Billing;
using Squidex.Infrastructure.Validation;

namespace Squidex.Areas.Api.Controllers.Plans.Models
{
    public sealed class PlansDto
    {
        /// <summary>
        /// The available plans.
        /// </summary>
        [LocalizedRequired]
        public PlanDto[] Plans { get; set; }

        /// <summary>
        /// The current plan id.
        /// </summary>
        public string? CurrentPlanId { get; set; }

        /// <summary>
        /// The plan owner.
        /// </summary>
        public string? PlanOwner { get; set; }

        /// <summary>
        /// The link to the management portal.
        /// </summary>
        public string? PortalLink { get; set; }

        /// <summary>
        /// The reason why the plan cannot be changed.
        /// </summary>
        public PlansLockedReason Locked { get; set; }

        public static PlansDto FromDomain(Plan[] plans, string? owner, string planId, Uri? portalLink, PlansLockedReason locked)
        {
            var result = new PlansDto
            {
                Locked = locked,
                CurrentPlanId = planId,
                Plans = plans.Select(PlanDto.FromDomain).ToArray(),
                PlanOwner = owner,
                PortalLink = portalLink?.ToString()
            };

            return result;
        }
    }
}
