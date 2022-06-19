using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Entities.Events.Distributed;
using Volo.Abp.EventBus.Distributed;
//using Volo.Abp.GlobalFeatures;
using Volo.Abp.Users;
//using Volo.CmsKit.GlobalFeatures;

namespace Acme.BookStore.Users;

public class BookUserSynchronizer :
    IDistributedEventHandler<EntityUpdatedEto<UserEto>>,
    ITransientDependency
{
    protected IBookUserRepository UserRepository { get; }

    protected IBookUserLookupService UserLookupService { get; }

    public BookUserSynchronizer(
        IBookUserRepository userRepository,
        IBookUserLookupService userLookupService)
    {
        UserRepository = userRepository;
        UserLookupService = userLookupService;
    }

    public virtual async Task HandleEventAsync(EntityUpdatedEto<UserEto> eventData)
    {
        //if (!GlobalFeatureManager.Instance.IsEnabled<CmsUserFeature>())
        //{
        //    return;
        //}

        var user = await UserRepository.FindAsync(eventData.Entity.Id);
        if (user == null)
        {
            user = await UserLookupService.FindByIdAsync(eventData.Entity.Id);
            if (user == null)
            {
                return;
            }
        }

        if (user.Update(eventData.Entity))
        {
            await UserRepository.UpdateAsync(user);
        }
    }
}
