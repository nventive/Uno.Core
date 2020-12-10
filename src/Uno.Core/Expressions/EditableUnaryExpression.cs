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

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Uno.Extensions;

namespace Uno.Expressions
{
	public class EditableUnaryExpression : EditableExpression<UnaryExpression>
	{
		public EditableUnaryExpression(UnaryExpression expression)
			: base(expression)
		{
			Type = expression.Type;
			Operand = expression.Operand.Edit();
		}

		public Type Type { get; set; }

		public IEditableExpression Operand { get; set; }

		public override IEnumerable<IEditableExpression> Nodes
		{
			get { yield return Operand; }
		}

		public override UnaryExpression DoToExpression()
		{
			return Expression.MakeUnary(NodeType, Operand.ToExpression(), Type);
		}
	}
}
