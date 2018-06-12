﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using IgiCore.SDK.Core.Models;
using JetBrains.Annotations;
using Roleplay.Core.Models.Player;

namespace Banking.Core.Models
{
	[PublicAPI]
	public class BankAccountMember : IdentityModel
	{
		[Required]
		[ForeignKey("Member")]
		public Guid MemberId { get; set; }

		public virtual Character Member { get; set; }

		[Required]
		[ForeignKey("Account")]
		public Guid AccountId { get; set; }

		public virtual BankAccount Account { get; set; }
	}
}
