﻿using System;

namespace Formula_1_App.Models;

public class ResultStatus : Entity
{
    public override int? Id { get; set; }
    public string Status { get; set; } = string.Empty;
}
