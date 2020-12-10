// ******************************************************************
// Copyright � 2015-2020 nventive inc. All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//      http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// ******************************************************************

using System.Collections.Generic;
using System.Linq.Expressions;
using Uno.Extensions;

namespace Uno.Expressions
{
	public class EditableMemberInitExpression : EditableExpression<MemberInitExpression>
	{
		private readonly List<MemberBinding> bindings;

		public EditableMemberInitExpression(MemberInitExpression expression)
			: base(expression, false)
		{
			NewExpression = expression.NewExpression.Edit();
			bindings = new List<MemberBinding>(expression.Bindings);
		}

		public EditableNewExpression NewExpression { get; set; }

		public IList<MemberBinding> Bindings
		{
			get { return bindings; }
		}

		public override IEnumerable<IEditableExpression> Nodes
		{
			get { yield return NewExpression; }
		}

		public override MemberInitExpression DoToExpression()
		{
			return Expression.MemberInit(NewExpression.DoToExpression(), Bindings);
		}
	}
}
