#region Copyright & License Information
/*
 * Copyright 2007-2019 The OpenRA Developers (see AUTHORS)
 * This file is part of OpenRA, which is free software. It is made
 * available to you under the terms of the GNU General Public License
 * as published by the Free Software Foundation, either version 3 of
 * the License, or (at your option) any later version. For more
 * information, see COPYING.
 */
#endregion

using OpenRA.Activities;
using OpenRA.Mods.Common.Traits;
using OpenRA.Mods.RA2.Traits;

namespace OpenRA.Mods.RA2.Activities
{
	public class HeliUndeployForGrantedCondition : Activity
	{
		readonly HeliGrantConditionOnDeploy deploy;

		public HeliUndeployForGrantedCondition(Actor self, HeliGrantConditionOnDeploy deploy)
		{
			this.deploy = deploy;
		}

		public override Activity Tick(Actor self)
		{
			IsInterruptible = false; // must DEPLOY from now.
			deploy.Undeploy();

			// Wait for deployment
			if (deploy.DeployState == DeployState.Undeploying)
				return this;

			return NextActivity;
		}
	}
}
