using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using core.Domain;

namespace core.Service
{
    public interface QuestService
    {
        void addQuest(QuestName questName);
        void removeQuest(QuestName questName);
    }
}
